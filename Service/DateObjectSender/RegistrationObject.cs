using System.Runtime.Serialization;

namespace Service.DateObjectSender
{
    [DataContract]
    public class RegistrationObject
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
