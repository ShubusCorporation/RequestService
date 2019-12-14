using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft;
using Newtonsoft.Json;
using LogLibrary;

namespace RequestService
{
    public interface ISaveStrategy
    {
        bool SaveRequest(BaseRequest aRequest);
        void SetRepository(DataRepository aRepository);
    }


    public class RequestSaver : ISaveStrategy
    {
        private DataRepository _Repository = null;

        public RequestSaver()
        {
        }

        public RequestSaver(DataRepository aRepository)
        {
            _Repository = aRepository;
        }

        public void SetRepository(DataRepository aRepository)
        {
            _Repository = aRepository;
        }

        public bool SaveRequest(BaseRequest aUserRequest)
        {
            if (_Repository == null)
            {
                return false;
            }
            try
            {
                string line = JsonConvert.SerializeObject(aUserRequest);
                _Repository.SaveLine(line);
            }
            catch (Exception ex)
            {
                LogWrapper.Log(MessageType.MESSAGE_FATALERROR, string.Format("Ошибка {0} при сохранении заявки {1}", ex.Message, ex.StackTrace));
                throw;
            }
            return true;
        }
    }
}