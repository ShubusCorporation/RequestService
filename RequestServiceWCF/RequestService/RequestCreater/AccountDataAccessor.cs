using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft;
using Newtonsoft.Json;
using MyLog;

namespace RequestService
{
    public class AccountDataAccessor
    {
        private static string _AccountFileStorage = "Accounts.db";
        private static FileAccessProvider _FileAccessProvider = null;

        static AccountDataAccessor()
        {
            _FileAccessProvider = new FileAccessProvider(_AccountFileStorage);
        }


        public static void SaveAccount(string Login, UserData aUserData)
        {
            KeyValuePair<string, UserData> kvp = new KeyValuePair<string, UserData>(Login, aUserData);
            string jsonAccount = JsonConvert.SerializeObject(kvp);
            _FileAccessProvider.SaveLine(jsonAccount);
        }
        

        public static void LoadAccounts(Dictionary<string, UserData> AccountTable)
        {
            string[] jsonKvp = _FileAccessProvider.LoadLines();

            try
            {
                foreach (string s in jsonKvp)
                {
                    if (string.IsNullOrWhiteSpace(s)) continue;

                    KeyValuePair<string, UserData> kvp = JsonConvert.DeserializeObject<KeyValuePair<string, UserData>>(s);
                    AccountTable.Add(kvp.Key, kvp.Value);
                }
            }
            catch (Exception ex)
            {
                LogWriter.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при десериализации аккаунтов. {1}", ex.Message, ex.StackTrace));
                throw;
            }
        }
    }
}