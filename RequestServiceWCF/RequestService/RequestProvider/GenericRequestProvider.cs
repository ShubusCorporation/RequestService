using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestService
{
    public class GenericRequestProvider<R> where R : BaseRequest
    {
        IGenericLoader<R> _Loader = null;

        public GenericRequestProvider(IGenericLoader<R> aLoader)
        {
            _Loader = aLoader;
        }

        public List<R> GetRequests(Int64 UserId)
        {
            List<R> ret = new List<R>();

            var res = _Loader.LoadRequests();

            if (res == null || res.Count() == 0 || res.ContainsKey(UserId) == false)
            {
                return ret;
            }
            return res[UserId];
        }
    }
}