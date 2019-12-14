using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.ServiceModel;
using MyLog;

namespace RequestService
{
    public static class AccountManager
    {
        private static Dictionary<string, UserData> _AccountTable = new Dictionary<string,UserData>();
        private static MD5 _Md5Hasher = MD5.Create();        

        static AccountManager()
        {            
            AccountDataAccessor.LoadAccounts(_AccountTable);
        }

        private static string CalculateMD5Hash(string input)
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = _Md5Hasher.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static bool RegisterAccount(string Login, string Password)
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                LogWriter.Log(MessageType.MESSAGE_ERROR, string.Format("Ошибка регистрации пользователя {0}", String.IsNullOrWhiteSpace(Login) ? "с пустым логином" : Login));
                return false;
            } 
            if (_AccountTable.ContainsKey(Login))
            {
                LogWriter.Log(MessageType.MESSAGE_ERROR, string.Format("Ошибка регистрации : логин {0} занят", Login));
                return false;
            }

            int lastId = _AccountTable.Count == 0 ? 1 : _AccountTable.ElementAt(_AccountTable.Count - 1).Value.UserId;

            if (lastId == int.MaxValue)
            {
                LogWriter.Log(MessageType.MESSAGE_ERROR, "Ошибка регистрации : Регистрация новых пользователей в системе завершена.");
                return false;
            }
            try
            {
                var newUserData = new UserData(-1, CalculateMD5Hash(Password));
                newUserData.FillUserData(_AccountTable);
                AccountDataAccessor.SaveAccount(Login, newUserData);
                _AccountTable[Login] = newUserData;
            }
            catch (Exception ex)
            {
                LogWriter.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при регистрации пользователя {1}. {2}", ex.Message, Login, ex.StackTrace));
                throw; // save call stack
            }
            return true;
        }


        public static bool Validate(string Login, string Password, out int UserId)
        {
            UserId = -1;

            if (_AccountTable.ContainsKey(Login) == false)
            {
                LogWriter.Log(MessageType.MESSAGE_ERROR, string.Format("Ошибка входа пользователя {0} : логин не зарегестрирован", Login));
                return false;
            }
            string pswMD5 = CalculateMD5Hash(Password);
            bool check =  pswMD5.Equals(_AccountTable[Login].PswStr);

            if (check)
            {
                UserId = _AccountTable[Login].UserId;
                LogWriter.Log(MessageType.MESSAGE_DEBUG, string.Format("Успешный вход : пользователю с логином {0} сопоставлен UserId = {1}", Login, UserId.ToString()));
            }
            else
            {
                LogWriter.Log(MessageType.MESSAGE_ERROR, string.Format("Ошибка входа пользователя {0} : пароль неверный", Login));
            }
            return check;
        }
    }
}