using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestService
{
    public class GenericRequest<T> : BaseRequest where T : BaseRequestParams
    {        
        public T _RequestParameters { get; set; }

        public GenericRequest(Int64 aUserId, T aRequestParams)
        {
            this._UserId = aUserId;
            _RequestParameters = aRequestParams;
        }    
    }
}