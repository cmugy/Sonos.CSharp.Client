using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract (Namespace = "")]
    public class SetGroupVolume
    {
        [DataMember (Name = "volume")] public int Volume { get; set; }
        [DataMember (Name = "groupId")] public string GroupId { get; set; }
    }
}