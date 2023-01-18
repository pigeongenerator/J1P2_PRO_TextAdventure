using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class LookCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public LookCommand(World _world, Player _player) : base("look")
        {
            world = _world;
            player = _player;
        }

        public override void Run()
        {
            int x = player.GetPosition().x;
            int y = player.GetPosition().y;

            LookAt(x, y + 1, "north");
            LookAt(x + 1, y, "east");
            LookAt(x, y - 1, "south");
            LookAt(x - 1, y, "west");
        }

        private void LookAt(int _x, int _y, string _direction)
        {
            Tile tile = world.GetTile(_x, _y);
            Console.WriteLine(GetMessage(tile, _direction));
        }

        private string GetMessage(Tile _tile, string _direction)
        {
            return $"{_direction} you see " + _tile.Type switch
            {
                TileType.shrubbery => "a shrubbery.",
                TileType.grass => "a patch of grass",
                TileType.water => "a lake",
                TileType.tree => "a tree",
                TileType.axe => "a patch of grass with something hidden inside.",
                TileType.food => "a patch of grass with something hidden inside.",
                TileType.mountain => "the mountain",
                TileType.start => "where you landed",
                _ => throw new NotImplementedException()
            };
        }
    }
}
