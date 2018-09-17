using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract (Namespace = "")]
    public class HouseHold
    {
        [DataMember (Name = "id")] public string Id { get; set; }
    }
}