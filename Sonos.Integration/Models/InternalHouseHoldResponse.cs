using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract (Namespace = "")]
    public class InternalHouseHoldResponse
    {
        [DataMember (Name = "groups")] public IEnumerable<Group> Groups { get; set; }
        
        [DataMember (Name = "players")] public IEnumerable<Player> Players { get; set; }
        
    }
}