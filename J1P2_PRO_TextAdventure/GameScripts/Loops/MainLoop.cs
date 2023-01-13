using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.GameScripts.Loops
{
    internal class MainLoop : Loop
    {
        private readonly World world;


        public MainLoop(World _world)
        {
            world = _world;
        }

        protected override bool LoopCondition()
        {
            (int posX, int posY) = world.Player.GetPosition();

            if (world.GetTile(posX, posY).Type == TileType.mountain)
            {
                return false;
            }

            return true;
        }

        protected override void DuringLoop()
        {
            string input;
            InputLoop inputLoop = new("What do you want to do?");

            Console.WriteLine();
            inputLoop.Start();

            input = inputLoop.GetInput();

#warning please find a better solution for input
            if (input.StartsWith("go"))
            {
                if (TryMoveInput(input, "north", 0, 1)) { }
                else if (TryMoveInput(input, "east", 1, 0)) { }
                else if (TryMoveInput(input, "south", 0, -1)) { }
                else if (TryMoveInput(input, "west", -1, 0)) { }
                else
                {
                    Console.WriteLine(" You don't know how to go there.");
                }
            }
            else if (input.StartsWith("build") && input.EndsWith("boat"))
            {
                int woodCount = world.Player.Wood;

                if (woodCount >= 4)
                {
                    world.Player.Wood -= 4;
                    world.Player.HasBoat = true;
                    Console.WriteLine(" You built a boat with 4 of the wood that you have.");
                }
                else
                {
                    Console.WriteLine($" You only have {woodCount} wood, you need 4 wood to build a boat.");
                }
            }
            else if (input.StartsWith("help"))
            {
                Console.WriteLine(" how to win: move around and find the rusty axe to cut down the trees. Then craft a boat to get over the water.\n Finally get the food to get up the mountain.\n\n commands (only necessary parts):\n  \"go [north|east|south|west]\" to move around,\n  \"craft boat\" crafts a boat if you have at least 4 wood,\n  \"help\" brings up this prompt");
            }
            else
            {
                Console.WriteLine($" I do not know how to do this thing: \"{input}\"");
            }
        }

        private bool TryMoveInput(string _input, string _endsWith, int _dX, int _dY)
        {
            if (_input.EndsWith(_endsWith))
            {
                world.Player.Move(_dX, _dY, world);
                return true;
            }

            return false;
        }
    }
}
