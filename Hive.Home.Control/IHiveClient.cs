using Sonos.Integration.Models.Hive;

namespace Hive.Home.Control
{
    public interface IHiveClient
    {
        void ConnectToHive(HiveLoginRequest request);
    }
}
