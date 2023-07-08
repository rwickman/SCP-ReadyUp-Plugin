#pragma warning disable SA1402
using System;
using System.Collections.Generic;
using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;

namespace ReadyUpPlugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class ReadyUp : ICommand
    {
        public string Command { get; } = "ready";
        public string[] Aliases { get; } = { "Ready", "R" };
        public string Description { get; } = "A command that indicates you are ready";



        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Round.IsLobby)
            {
                if (sender is PlayerCommandSender player)
                {
                    if (!Data.playersReady.Contains(player.Nickname))
                    {
                        Data.playersReady.Add(player.Nickname);

                        Map.Broadcast(
                            ReadyUpPlugin.Instance.Config.BroadcastLength,
                            $"{player.Nickname} is ready! There are now {Data.playersReady.Count} players ready!",
                            shouldClearPrevious: true);

                        response = $"You are ready! You can unready by entering .wait in the console.";
                        return true;
                    }
                    else
                    {
                        response = $"You are already ready! You can unready by entering .wait in the console.";
                        return false;
                    }

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
