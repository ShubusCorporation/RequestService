using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogLibrary;
using Newtonsoft.Json;

namespace RequestService
{
    public interface IGenericLoader<T> where T : BaseRequest
    {
        Dictionary<Int64, List<T>> LoadRequests();
    }

    public class RequestLoader<T> : IGenericLoader<T> where T : BaseRequest
    {
        DataRepository _Repository;

        public RequestLoader(DataRepository aRepository)
        {
            _Repository = aRepository;
        }

        public Dictionary<Int64, List<T>> LoadRequests()
        {
            string[] jsonKvp = _Repository.LoadLines();
            Dictionary<Int64, List<T>> ret = new Dictionary<long, List<T>>();

            try
            {
                foreach (string s in jsonKvp)
                {
                    if (string.IsNullOrWhiteSpace(s)) continue;

                    T request = JsonConvert.DeserializeObject<T>(s);
                    List<T> listUserRequest = null;

                    if (!ret.TryGetValue(request._UserId, out listUserRequest))
                    {
                        listUserRequest = new List<T>();
                        ret[request._UserId] = listUserRequest;
                    }
                    listUserRequest.Add(request);
                }
            }
            catch (Exception ex)
            {
                LogWrapper.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при десериализации заявок. {1}", ex.Message, ex.StackTrace));
                throw;
            }
            return ret;
        }
    }
}
