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

        public override void Run()
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
                    MovePlayer(-1, 0);
                    break;

                default:
                    throw new Exception($"unknown case: {Argument}");
            }
        }

        private void MovePlayer(int _dx, int _dy)
        {
            (int x, int y) = player.GetPosition();
            player.Move(_dx, _dy, world);

            x += _dx;
            y += _dy;

            Console.WriteLine(world.GetTile(x, y).OnEnter(player));
        }
    }
}
