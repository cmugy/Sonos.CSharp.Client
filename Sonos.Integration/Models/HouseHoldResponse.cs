using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract (Namespace = "")]
    public class HouseHoldResponse
    {
        [DataMember (Name = "households")]
        public IEnumerable<HouseHold> HouseHolds { get; set; }
        
    }
}