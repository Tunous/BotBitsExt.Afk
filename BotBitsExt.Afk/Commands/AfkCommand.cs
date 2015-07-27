﻿using System;
using BotBits;
using BotBits.Commands;

namespace BotBitsExt.Afk.Commands
{
    /// <summary>
    /// Afk command used to change afk state.
    /// </summary>
    public sealed class AfkCommand : Package<AfkCommand>
    {
        public AfkCommand()
        {
            InitializeFinish += delegate { CommandLoader.Of(BotBits).Load(this); };
        }

        [Command(0, "afk", "unafk")]
        private void OnCommand(IInvokeSource source, ParsedRequest request)
        {
            var player = source.ToPlayerInvokeSource().Player;
            var isAfk = player.IsAfk(considerAutoAfk: false);

            if (request.Type == "unafk" || isAfk)
            {
                player.SetAfk(false);
                source.Reply("You are no longer afk.");
            }
            else
            {
                player.SetAfk(true);
                source.Reply("You are now afk.");
            }
        }
    }
}

