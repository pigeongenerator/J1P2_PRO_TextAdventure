using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class GoCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public GoCommand(World _world, Player _player) : base("go", "north", "east", "south", "west")
        {
            world = _world;
            player = _player;
        }

        /// <summary>
        /// moves the player based on cardinal directions. e.g. north, south, east, west
        /// </summary>
        /// <exception cref="Exception"></exception>
        public override void Run()
        {
            switch (Argument) //switch statement for argument
            {
                case "north":
                    MovePlayer(0, 1); //moves the player relative to the player's current position
                    break;

                case "east":
                    MovePlayer(1, 0);
                    break;

                case "south":
                    MovePlayer(0, -1);
                    break;

                case "west":
                    MovePlayer(-1, 0);
                    break;

                default:
                    throw new Exception($"unknown case: {Argument}");
            }
        }

        /// <summary>
        /// moves the player relative to the player
        /// </summary>
        /// <param name="_dx">the distance in the X direction the player should travel</param>
        /// <param name="_dy">the distance in the Y direction the player should travel</param>
        private void MovePlayer(int _dx, int _dy)
        {
            (int x, int y) = player.GetPosition(); //gets the player's current position
            player.Move(_dx, _dy, world); //moves the player
            Tile enteredTile;

            x += _dx;
            y += _dy;

            enteredTile = world.GetTile(x, y); //gets the entered tile
            Console.WriteLine(enteredTile.OnEnter(player)); //writes the message of the attempted entered tile
        }
    }
}
