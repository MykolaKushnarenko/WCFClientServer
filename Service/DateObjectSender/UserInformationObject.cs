using System.Runtime.Serialization;

namespace Service.DateObjectSender
{
    [DataContract]
    public class UserInformationObject
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
    }
}
