using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RequestService
{
    [ServiceContract(ProtectionLevel=ProtectionLevel.None)]
    public interface IRequestService
    {
        [OperationContract]
        bool Create(Int64 UserId, RequestType requestType, object requestParams);

        [OperationContract]
        UserRequestCollection GetRequests(Int64 UserId); 
    }
}
