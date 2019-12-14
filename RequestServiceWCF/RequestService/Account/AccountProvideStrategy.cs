using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using LogLibrary;

namespace RequestService
{
    public interface IAccountProvideStrategy
    {
        void SaveAccount(Int64 UserId);
        HashSet<Int64> LoadAccounts();
    }

    public class AccountProvideStrategy : IAccountProvideStrategy
    {
        private DataRepository _Repository = null;

        public AccountProvideStrategy(DataRepository aRepository)
        {
            _Repository = aRepository;
        }


        public void SaveAccount(Int64 UserId)
        {
            _Repository.SaveLine(UserId.ToString());
        }


        public HashSet<Int64> LoadAccounts()
        {
            string[] acc = null;
            HashSet<Int64> ret = new HashSet<long>();

            try
            {
                acc = _Repository.LoadLines();

                foreach (string s in acc)
                {
                    ret.Add(Convert.ToInt64(s));
                }
            }
            catch (Exception ex)
            {
                LogWrapper.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при загрузке аккаунтов. {1}", ex.Message, ex.StackTrace));
                throw;
            }
            return ret;
        }
    }
}