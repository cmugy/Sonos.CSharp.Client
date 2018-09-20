using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sonos.Integration.Models.Request
{
    [DataContract (Namespace = "")]
    public class PlayerRequest
    {
        //[DataMember (Name = "players")] public IEnumerable<Player> Players { get; set; }
        [DataMember (Name = "playerIds")] public IEnumerable<string> PlayerIds { get; set; } 
        
        [DataMember (Name = "householdId")] public string HouseholdId { get; set; }
    }
}