using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract (Namespace = "")]
    public class Session
    {
        [DataMember (Name = "id")] public int Id { get; set; }
        
        [DataMember (Name = "state")] public string State { get; set; }
        
    }
}