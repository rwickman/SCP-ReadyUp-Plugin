using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using ReadyUpPlugin.Commands;

namespace ReadyUpPlugin.Handlers
{

    internal class Player
    {
        public void OnLeft(LeftEventArgs ev)
        {
            Data.playersReady.Remove(ev.Player.Nickname);
        }

        public void OnJoined(JoinedEventArgs ev)
        {
            if (Round.IsLobby)
            {
                Map.Broadcast(
                ReadyUpPlugin.Instance.Config.BroadcastLength,
                $"Hey please ready up by pressing ` on your keyboard and typing .ready.");
            }
            
        }
    }
}
