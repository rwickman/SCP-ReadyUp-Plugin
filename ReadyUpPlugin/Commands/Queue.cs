#pragma warning disable SA1402
using System;
using System.Collections.Generic;
using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;

namespace ReadyUpPlugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class Queue : ICommand
    {
        public string Command { get; } = "queue";
        public string[] Aliases { get; } = { "Queue", "Q" };
        public string Description { get; } = "A command that shows a queue of who all is ready.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Round.IsLobby)
            {
                response = "";                
                int numNotReady = 0;

                foreach (Player player in Player.List)
                {


                    if (!Data.playersReady.Contains(player.Nickname))
                    {
                        ++numNotReady;
                        if (numNotReady == 1)
                        {
                            response += "Players that are not ready:\n";
                        }
                        response += player.Nickname + "\n";
                    }

                }

                if (Data.playersReady.Count > 0)
                {
                    response += "Players that are ready:\n";
                }

                foreach (string readyPlayer in Data.playersReady)
                {
                    response += readyPlayer + "\n";
                }
                return true;
            }
            else
            {
                response = "This command only works if you are in the lobby!";
                return false;
            }

        }
    }
}
