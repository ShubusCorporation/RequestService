using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml;

namespace RequestService
{
    public class CustomRequestResolver : DataContractResolver
    {
        public override bool TryResolveType(Type dataContractType, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            return knownTypeResolver.TryResolveType(dataContractType, declaredType, null, out typeName, out typeNamespace);
        }
        

        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            if (string.Equals(typeNamespace, "http://schemas.datacontract.org/2004/07/RequestService", StringComparison.OrdinalIgnoreCase))
            {
                if (typeName == "SeldonRequestParams")
                {
                    return typeof(SeldonRequestParams);
                }
                else if (typeName == "JusticeRequestParams")
                {
                    return typeof(JusticeRequestParams);
                }
                else if (typeName == "LearningRequestParams")
                {
                    return typeof(LearningRequestParams);
                }
            }
            return knownTypeResolver.ResolveName(typeName, typeNamespace, null, knownTypeResolver);
        }
    }
}