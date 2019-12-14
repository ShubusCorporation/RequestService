using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RequestService
{
    [DataContract(Name = "LearningRequestParams")]
    public class LearningRequestParams : BaseRequestParams
    {
        [DataMember]
        public string course;
        [DataMember]
        public int price;
        [DataMember]
        public string lector;
        [DataMember]
        public string address;
    }
}