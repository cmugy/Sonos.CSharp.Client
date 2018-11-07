using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sonos.Integration.Models.Hue
{
    [DataContract]
    public class UserResponse
    {
        [DataMember(Name = "username")]
        public string UserName { get; set; }
    }
}
