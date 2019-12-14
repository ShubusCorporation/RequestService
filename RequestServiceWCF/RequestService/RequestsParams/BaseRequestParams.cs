using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RequestService
{
    [DataContract]
    [KnownType(typeof(JusticeRequestParams))]
    [KnownType(typeof(LearningRequestParams))]
    [KnownType(typeof(SeldonRequestParams))]

    public abstract class BaseRequestParams
    {
    }
}