using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestService
{
    public interface IRequestProvider
    {
        UserRequestCollection GetRequests(Int64 UserId);
    }


    public class RequestProvider : IRequestProvider
    {
        GenericRequestProvider<GenericRequest<SeldonRequestParams>> _SRequestProvider = null;
        GenericRequestProvider<GenericRequest<LearningRequestParams>> _LRequestProvider = null;
        GenericRequestProvider<GenericRequest<JusticeRequestParams>> _JRequestProvider = null;


        // Loaders are load strategies for request providers;
        public RequestProvider(IGenericLoader<GenericRequest<SeldonRequestParams>> SLoader,
                               IGenericLoader<GenericRequest<LearningRequestParams>> LLoader,
                               IGenericLoader<GenericRequest<JusticeRequestParams>> JLoader)
        {
           _SRequestProvider = new GenericRequestProvider<GenericRequest<SeldonRequestParams>>(SLoader);
           _LRequestProvider = new GenericRequestProvider<GenericRequest<LearningRequestParams>>(LLoader);
           _JRequestProvider = new GenericRequestProvider<GenericRequest<JusticeRequestParams>>(JLoader);
        }


        public UserRequestCollection GetRequests(Int64 UserId)
        {
            UserRequestCollection ret = new UserRequestCollection();

            _SRequestProvider.GetRequests(UserId).ForEach(x => ret._SeldonRequestsParams.Add(x._RequestParameters));
            _LRequestProvider.GetRequests(UserId).ForEach(x => ret._LearningRequestsParams.Add(x._RequestParameters));
            _JRequestProvider.GetRequests(UserId).ForEach(x => ret._JusticeRequestsParams.Add(x._RequestParameters));
            return ret;
        }
    }
}