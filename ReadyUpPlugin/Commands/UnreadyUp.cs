#pragma warning disable SA1402
using System;
using System.Collections.Generic;
using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;

namespace ReadyUpPlugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class UnreadyUp : ICommand
    {
        public string Command { get; } = "unready";
        public string[] Aliases { get; } = { "Unready", "UR", "wait" };
        public string Description { get; } = "A command that indicates you are not ready.";


        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Round.IsLobby)
            {
                if (sender is PlayerCommandSender player)
                {
                    Data.playersReady.Remove(player.Nickname);

                    Map.Broadcast(
                        ReadyUpPlugin.Instance.Config.BroadcastLength,
                        $"{player.Nickname} needs a minute! There are now {Data.playersReady.Count} players ready!",
                        shouldClearPrevious: true);

                    response = "Ready up by entering .ready in the console.";
                    return true;
                }
                else
                {
                    response = "Server is ready.";
                    return false;
                }
            }
            else
            {
                response = "This command only works if you are in the lobby!";
                return false;
            }
            
        }
    }
}
