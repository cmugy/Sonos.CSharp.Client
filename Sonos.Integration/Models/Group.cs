using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract (Namespace = "")]
    public class Group
    {
        [DataMember (Name = "id")] public int Id { get; set; }
        
        [DataMember (Name = "name")] public string Name { get; set; }       
    }
}