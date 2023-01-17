﻿using J1P2_PRO_TextAdventure.Assets;
using J1P2_PRO_TextAdventure.Assets.Commands;
using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.GameScripts.Loops
{
    internal class MainLoop : Loop
    {
        private readonly World world;
        private readonly Command[] commands;


        public MainLoop(World _world)
        {
            world = _world;
            commands = new Command[]
            {
                new GoCommand(world, world.Player),
                new TakeCommand(world, world.Player),
                new EatCommand(world, world.Player),
                new UseCommand(world, world.Player),
                new MakeCommand(world.Player),
                new LookCommand(world, world.Player),
                new HelpCommand(world, world.Player),
            };
        }

        /// <summary>
        /// start of MainLoop
        /// </summary>
        protected override void OnStart()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("hint: type \"help\" if you're stuck.");
            Console.ResetColor();
        }

        /// <summary>
        /// checks if the player is on the mountain
        /// </summary>
        /// <returns><see langword="true"/> if the player's position is on a mountain tile. Otherwise <see langword="false"/></returns>
        protected override bool LoopCondition()
        {
            Tile playerTile = world.GetPlayerTile();

            if (playerTile.Type == TileType.mountain)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// gets player's input & tries to run the corresponding command
        /// </summary>
        protected override void DuringLoop()
        {
            string input;
            bool commandSuccess = false;
            InputLoop inputLoop = new();

            inputLoop.Start();
            input = inputLoop.GetInput();

            foreach (Command command in commands) //loops through all commands 
            {
                if (command.IsCommand(input))
                {
                    command.Run();
                    commandSuccess = true;
                    break; //breaks out of the loop
                }
            }

            if (commandSuccess == false)
            {
                Console.WriteLine($"You don't know how to: \"{input}\".");
            }
        }

        /// <summary>
        /// prints the final dialogue.
        /// </summary>
        protected override void OnEnd()
        {
            Dialogue endDialogue;
            Dialogue finalDialogue;

            endDialogue = new(
                "it was a excruciating climb, but Jesse managed it just because of the beans.",
                "Jesse inspected the RV, the equipment didn't survive but luckily the built cool-box protected some food and water from the flames.",
                "Jesse started walking.",
                "and walking..",
                "and walking...",
                "after a full week of walking Jesse ran out of water",
                "Then finally, a car drove by.",
                "Jesse tried to hitch hike and the car stopped",
                "Jesse explained the situation and the person was glad to help");
            endDialogue.Start();


            finalDialogue = new("Finally when reaching Jesse's family, Jesse was very happy to see them and told them all about his adventure.")
            { ContinuePrompt = "the end." };

            finalDialogue.Start();
        }
    }
}
