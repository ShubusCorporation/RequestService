using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.ServiceModel;
using LogLibrary;
using MD5Hasher;

namespace RequestService
{
    public interface IAccountValidator
    {
        bool RegisterAccount(Int64 UserId);
        bool Validate(string Login, string Password);
    }


    public class AccountValidator : IAccountValidator
    {
        private IAccountProvideStrategy _AccountProvider = null;
        private HashSet<long> _UserTable = null;
        private Int64 _ServerLoginKey = 6337652915524363660;


        public AccountValidator(IAccountProvideStrategy aAccountProvideStrategy)
        {
            _AccountProvider = aAccountProvideStrategy;
            _UserTable = _AccountProvider.LoadAccounts();
        }

        public bool RegisterAccount(Int64 UserId)
        {
            if (_UserTable.Contains(UserId))
            {
                LogWrapper.Log(MessageType.MESSAGE_ERROR, string.Format("Ошибка регистрации : UserId {0} занят", UserId.ToString()));
                return false;
            }
            try
            {
                _AccountProvider.SaveAccount(UserId);

                lock (_UserTable)
                {
                    _UserTable.Add(UserId);
                }
            }
            catch (Exception ex)
            {
                LogWrapper.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при регистрации пользователя {1}. {2}", ex.Message, UserId.ToString(), ex.StackTrace));
                throw;
            }
            return true;
        }


        public bool Validate(string Login, string Password)
        {
            Int64 hashPsw = Convert.ToInt64(Password);
            Int64 hashLog = Convert.ToInt64(Login);

            if ((hashLog ^ hashPsw) != _ServerLoginKey)
            {
                LogWrapper.Log(MessageType.MESSAGE_ERROR, "Контрольное значение не совпадает");
                return false;
            }
            bool contains = false;

            lock (_UserTable)
            {
                contains = _UserTable.Contains(hashPsw);
            }
            if (!contains)
            {
                LogWrapper.Log(MessageType.MESSAGE_ERROR, "Ошибка входа пользователя");
                return false;
            }
            LogWrapper.Log(MessageType.MESSAGE_DEBUG, string.Format("Успешный вход : пользователю с логином {0} сопоставлен UserId = {1}", Login, hashPsw.ToString()));
            return true;
        }
    }
}
