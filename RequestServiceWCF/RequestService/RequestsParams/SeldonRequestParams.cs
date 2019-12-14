using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RequestService
{
    [DataContract(Name = "SeldonRequestParams")]
    public class SeldonRequestParams : BaseRequestParams
    {
        [DataMember]
        Version seldonVersion;
        [DataMember]
        int price;
        [DataMember]
        DateTime garante;
    }
}