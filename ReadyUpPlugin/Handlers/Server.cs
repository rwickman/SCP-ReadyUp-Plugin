using Exiled.API.Features;
using ReadyUpPlugin.Commands;

namespace ReadyUpPlugin.Handlers
{
    internal class Server
    {
        public void OnWaitingForPlayers()
        {
            Map.Broadcast(
                ReadyUpPlugin.Instance.Config.BroadcastLength,
                "Please ready up by pressing ` on your keyboard and typing .ready.");
            Data.playersReady.Clear();
        }
    }
}
