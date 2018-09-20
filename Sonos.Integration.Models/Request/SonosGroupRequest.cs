using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Serialization;

namespace Sonos.Integration.Models.Request
{
    [DataContract(Namespace = "")]
    public class SonosGroupRequest
    {
        [DataMember (Name = "playerIds")] public IEnumerable<string> PlayerIds { get; set; }
        [DataMember (Name = "musicContextGroupId")]
        public string MusicContextGroupId { get; set; }
    }
}