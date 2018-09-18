using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract (Namespace = "")]
    public class Group
    {
        [DataMember (Name = "id")] public string Id { get; set; }
        
        [DataMember (Name = "name")] public string Name { get; set; }  
        
        [DataMember (Name = "playbackState")] public string PlayBackState { get; set; }
        
        [DataMember (Name = "coordinatorId")] public string CoordinatorId { get; set; }
        
        [DataMember (Name = "playerIds")] public IEnumerable<string> PlayerIds { get; set; }
    }
}