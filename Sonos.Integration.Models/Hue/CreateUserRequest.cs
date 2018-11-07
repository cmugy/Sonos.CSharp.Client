using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Sonos.Integration.Models.Hue
{
    [DataContract(Namespace = "")]
    public class CreateUserRequest
    {

        [DataMember(Name = "devicetype")] public string DeviceType { get; set; }

    }
}
