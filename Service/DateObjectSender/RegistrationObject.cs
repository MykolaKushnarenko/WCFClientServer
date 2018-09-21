using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
