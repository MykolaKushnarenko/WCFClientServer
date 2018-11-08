using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using DetailsAnalysis.Core;

namespace Service.DateObjectSender.DetailAnalyz
{
    [DataContract]
    public class DAnalysMethodObject
    {
        [DataMember]
        public string Name;
        [DataMember]
        public IEnumerable<string> AllTypeInMethod;

        private DAnalysMethodObject(){}

        public static DAnalysMethodObject CreateSendObject(AnalysMethodInfo method)
        {
            return new DAnalysMethodObject()
            {
                Name = method.Name,
                AllTypeInMethod = method.StringFormatAllTypeInClass
            };
        }
    }
}