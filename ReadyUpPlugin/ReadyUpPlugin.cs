using Exiled.API.Enums;
using Exiled.API.Features;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using System.Runtime.InteropServices;

namespace ReadyUpPlugin
{
    public class ReadyUpPlugin : Plugin<Config>
    {
        private static readonly ReadyUpPlugin Singleton = new ReadyUpPlugin();
        public static ReadyUpPlugin Instance => Singleton;

        public override PluginPriority Priority { get; } = PluginPriority.Highest;

        private Handlers.Player player;
        private Handlers.Server server;

        private ReadyUpPlugin() { }


        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            player = new Handlers.Player();
            server = new Handlers.Server();

            Server.WaitingForPlayers += server.OnWaitingForPlayers;

            Player.Left += player.OnLeft;
            Player.Joined += player.OnJoined;
        }

        public void UnregisterEvents()
        {
            Server.WaitingForPlayers -= server.OnWaitingForPlayers;

            Player.Left -= player.OnLeft;
            Player.Joined -= player.OnJoined;

            player = null;
            server = null;
        }


    }
}
