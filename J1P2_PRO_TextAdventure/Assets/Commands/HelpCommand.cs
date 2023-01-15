using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class HelpCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public HelpCommand(World _world, Player _player) : base("help")
        {
            world = _world;
            player = _player;
        }

        public override void Run()
        {
            Tile playerTile = world.GetPlayerTile();

            if (playerTile.Type == TileType.axe || playerTile.Type == TileType.food)
            {
                Console.WriteLine("use \"take\" to take the item.");
            }

            if (player.HasAxe == false)
            {
                Console.WriteLine("use \"look\" to see what is around you and use \"go [north|east|south|west]\" to move around. You need to find a way to get food.");
            }
            else if (playerTile.Type == TileType.tree)
            {
                Console.WriteLine("use \"use axe\" to chop down the tree to get 1 wood.");
            }
            else if (player.Wood < 4 && player.HasBoat == false)
            {
                Console.WriteLine("find some trees to use the axe on.");
            }
            else if (player.Wood >= 4)
            {
                Console.WriteLine("use \"make boat\" to make a boat to get over water.");
            }

            if (player.HasBoat && player.IsHungry && player.HasFood == false)
            {
                Console.WriteLine("look if there is some food in the water.");
            }
            else if (player.HasFood || playerTile.Type == TileType.food)
            {
                Console.WriteLine("use \"eat\" to eat the food.");
            }
            else if (player.IsHungry == false)
            {
                Console.WriteLine("go back up the mountain to go back to civilization.");
            }
        }
    }
}
