using System.Runtime.Serialization;
using Ionic.Zip;

namespace Service.DateObjectSender
{
    [DataContract]
    public class AddingCodeObject
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string CompileType { get; set; }
        [DataMember]
        public bool IsSearch { get; set; }
        [DataMember]
        public bool IsAllAnalysis { get; set; }
        [DataMember ]
        public byte[] Solution { get; set; }
        [DataMember]
        public string FileMane { get; set; }
        [DataMember]
        public byte[] Code { get; set; }
        [DataMember]
        public bool CompareLocal { get; set; }
    }
}
