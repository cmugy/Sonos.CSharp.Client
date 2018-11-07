using System;
using System.Collections.Generic;
using System.Text;

namespace Phillips.Hue.Control
{
    public interface IPhillipsHueClient
    {
        void ConnectToHue();
        void CreateUser(string user);
    }
}
