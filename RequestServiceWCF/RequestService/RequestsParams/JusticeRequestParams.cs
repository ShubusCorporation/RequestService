using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RequestService
{
    [DataContract(Name = "JusticeRequestParams")]
    public class JusticeRequestParams : BaseRequestParams
    {
        [DataMember]
        public int price;
        [DataMember]
        public string phone;
        [DataMember]
        public string courtAddress;
        [DataMember]
        public string loyerName;
        [DataMember]
        public string debtorName;
    }
}