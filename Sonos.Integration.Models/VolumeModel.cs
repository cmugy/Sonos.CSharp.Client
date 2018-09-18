using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract (Namespace = "")]
    public class VolumeModel
    {
        [DataMember (Name = "volume")] public int Volume { get; set; }
        [DataMember (Name = "muted")] public bool Muted { get; set; }
        [DataMember (Name = "fixed")] public bool Fixed { get; set; }
    }
}