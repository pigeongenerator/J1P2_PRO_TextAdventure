using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class TakeCommand : Command
    {
        private readonly Player player;
        private readonly World world;


        public TakeCommand(Player _player, World _world) : base("take")
        {
            player = _player;
            world = _world;
        }

        public override void Run()
        {
            Tile currentTile = world.GetPlayerTile();

            switch (currentTile.Type)
            {
                case TileType.axe:
                    player.HasAxe = true;
                    currentTile.Type = TileType.grass;
                    Console.WriteLine("You took the rusty axe.");
                    break;

                case TileType.food:
                    player.HasFood = true;
                    Console.WriteLine("You took the food.");
                    break;

                default:
                    Console.WriteLine("You see nothing you can take.");
                    break;
            }
        }
    }
}
