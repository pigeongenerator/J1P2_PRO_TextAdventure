﻿using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class MakeCommand : Command
    {
        private readonly Player player;


        public MakeCommand(Player _player) : base("make", "boat")
        {
            player = _player;
        }

        public override void Run()
        {
            if (player.Wood >= 4)
            {
                player.Wood -= 4;
                Console.WriteLine("you made a boat from 4 wood!");
            }
            else
            {
                Console.WriteLine($"You can't make a boat, you need at least 4 wood; you only have {player.Wood}.");
            }
        }
    }
}
