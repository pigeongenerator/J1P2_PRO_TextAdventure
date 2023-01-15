using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class TakeCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public TakeCommand(World _world, Player _player) : base("take")
        {
            world = _world;
            player = _player;
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
                    Console.WriteLine("You took the can o' beans.");
                    break;

                default:
                    Console.WriteLine("You see nothing you can take.");
                    break;
            }
        }
    }
}
