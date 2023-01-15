using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class UseCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public UseCommand(World _world, Player _player) : base("use", "axe")
        {
            world = _world;
            player = _player;
        }

        public override void Run()
        {
            Tile playerTile = world.GetPlayerTile();
            if (playerTile.Type == TileType.tree && player.HasAxe)
            {
                playerTile.Type = TileType.grass;
                player.Wood += 1;

                Console.WriteLine($"you chopped down the tree, you now have {player.Wood} wood.");
            }
            else
            {
                Console.WriteLine("You don't know where to use the axe.");
            }
        }
    }
}
