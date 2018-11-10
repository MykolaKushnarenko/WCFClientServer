using System.Collections.Generic;
using System.Runtime.Serialization;
using Service.DateObjectSender.DetailAnalyz;

namespace Service.DateObjectSender
{
    [DataContract]
    public class ResultCompareObject
    {
        [DataMember]
        public string MainCodeText { get; set; }
        [DataMember]
        public string ChildCodeText { get; set; }
        [DataMember]
        public List<string> ResultCompare { get; set; }
        [DataMember]
        public bool IsLocalCompare { get; set; }
        [DataMember]
        public List<string> TokkingMainCode { get; set; }
        [DataMember]
        public List<string> TokkingChildCode { get; set; }
        [DataMember]
        public IEnumerable<DAnalysClassObject> DeteilAnalysRoslyn{ get; set; }
    }
}
