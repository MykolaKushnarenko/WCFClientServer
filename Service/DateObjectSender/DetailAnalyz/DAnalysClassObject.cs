using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using DetailsAnalysis.Core;
namespace Service.DateObjectSender.DetailAnalyz
{
    [DataContract]
    public class DAnalysClassObject
    {
        [DataMember]
        public string ClassName;
        [DataMember]
        public int CountOfMehod;
        [DataMember]
        public bool HasError;
        [DataMember]
        public IEnumerable<string> Error;
        [DataMember]
        public string BaseClasses;
        [DataMember]
        public IEnumerable<DAnalysMethodObject> AllMethod;
        //TODO: Method заменить, дурачек) 
        private DAnalysClassObject() {}

        public static DAnalysClassObject CreateSendObject(AnalysClassInfo Class)
        {
            IEnumerable<DAnalysMethodObject> result =
                Class.Method.Select(method => DAnalysMethodObject.CreateSendObject(method));
            return new DAnalysClassObject()
            {
                ClassName = Class.Name,
                BaseClasses = Class.BaseClasses,
                Error = Class.TextError,
                AllMethod = result,
                CountOfMehod = Class.StringFormatAllTypeInClass.Count()
            };
        }
    }
}