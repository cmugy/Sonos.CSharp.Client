using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract(Namespace = "")]
    public class Player
    {
        [DataMember(Name = "id")] public string Id { get; set; }

        [DataMember(Name = "name")] public string Name { get; set; }

        [DataMember(Name = "icon")] public string Icon { get; set; }

        [DataMember(Name = "softwareVersion")] public string SoftwareVersion { get; set; }
        
        [DataMember (Name = "deviceIds")] public IEnumerable<string> DeviceIds { get; set; }
        
        [DataMember (Name = "apiVersion")] public string ApiVersion { get; set; }
        
        [DataMember (Name = "capabilities")] public IEnumerable<string> Capabilities { get; set; }

    }
}