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
                    MovePlayer(1, 0);
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
