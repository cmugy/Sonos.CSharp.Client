using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract(Namespace = "")]
    public class VolumeControl
    {
        [DataMember (Name = "volume")] public int Volume { get; set; }
    }
}