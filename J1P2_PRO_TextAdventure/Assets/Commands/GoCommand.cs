using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class GoCommand : Command
    {
        Player player;
        World world;


        public GoCommand(Player _player, World _world) : base("go", "north", "east", "south", "west")
        {
            player = _player;
            world = _world;
        }

        protected override void OnRun()
        {
            switch (Argument)
            {
                case "north":
                    MovePlayer(0, 1);
                    break;

                case "east":
                    MovePlayer(1, 0);
                    break;

                case "south":
                    MovePlayer(0, -1);
                    break;

                case "west":
                    MovePlayer(1, 0);
                    break;

                default:
                    throw new Exception($"unknown case: {Argument}");
            }
        }

        /// <summary>
        /// tries to move the player, if it was a success a prompt will be played for what tile the player is now on
        /// </summary>
        /// <param name="_dx">the distance in the X direction that the player will try to move to</param>
        /// <param name="_dy">the distance in the Y direction that the player will try to move to</param>
        private void MovePlayer(int _dx, int _dy)
        {
            (int x, int y) originalPos, movedPos;
            int x, y;
            string prompt;

            originalPos = player.GetPosition();
            player.Move(_dx, _dy, world);
            movedPos = player.GetPosition();

            if (originalPos != movedPos)
            {
                x = movedPos.x;
                y = movedPos.y;

                prompt = world.GetTile(x, y).OnEnter(player);
                Console.WriteLine(prompt);
            }
        }
    }
}
