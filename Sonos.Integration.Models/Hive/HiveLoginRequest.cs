using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sonos.Integration.Models.Hive
{
    [DataContract(Namespace = "")]
    public class HiveLoginRequest
    {
        [DataMember(Name = "sessions")] public IEnumerable<Session> Sessions { get; set; }
    }
}
