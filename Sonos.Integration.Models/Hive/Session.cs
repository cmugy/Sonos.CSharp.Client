using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sonos.Integration.Models.Hive
{
    [DataContract (Namespace = "")]
    public class Session
    {
        [DataMember (Name = "username")] public string Username { get; set; }
        [DataMember (Name = "password")] public string Password { get; set; }
        [DataMember (Name = "caller")] public string Caller { get; set; }

    }
}
