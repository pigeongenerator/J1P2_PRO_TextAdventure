using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.Assets.Commands
{
    internal class EatCommand : Command
    {
        private readonly World world;
        private readonly Player player;


        public EatCommand(World _world, Player _player) : base("eat")
        {
            world = _world;
            player = _player;
        }

        public override void Run()
        {
            string sucessMessage = "You ate the delicious beans, you feel recharged!";
            Tile playerTile = world.GetPlayerTile();

            if (player.HasFood)
            {
                player.HasFood = false;
                player.IsHungry = false;
                Console.WriteLine(sucessMessage);
            }
            else if (playerTile.Type == TileType.food)
            {
                playerTile.Type = TileType.grass;
                player.IsHungry = false;
                Console.WriteLine(sucessMessage);
            }
            else
            {
                Console.WriteLine("You see nothing for you to eat.");
            }
        }
    }
}
