using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sonos.Integration.Models.Hue
{
    [DataContract]
    public class CreateUserResponse
    {
        [DataMember (Name = "success")]
        public UserResponse UserResponse { get; set; }
    }
}
