using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RequestService
{
    [DataContract]
    public class UserRequestCollection
    {
        [DataMember]
        public List<SeldonRequestParams> _SeldonRequestsParams;
        [DataMember]
        public List<JusticeRequestParams> _JusticeRequestsParams;
        [DataMember]
        public List<LearningRequestParams> _LearningRequestsParams;

        public UserRequestCollection()
        {
            _SeldonRequestsParams = new List<SeldonRequestParams>();
            _LearningRequestsParams = new List<LearningRequestParams>();
            _JusticeRequestsParams = new List<JusticeRequestParams>();
        }
    }
}