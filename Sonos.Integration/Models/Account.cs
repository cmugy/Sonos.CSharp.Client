using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract(Namespace = "")]
    public class Account
    {
        [DataMember(Name = "id")] public int Id { get; set; }
    }
}