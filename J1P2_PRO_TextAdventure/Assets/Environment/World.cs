namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class World
    {
        private readonly Tile[,] world;
        private readonly Player player;

        public Player Player { get { return player; } }


        public World()
        {
            int[] playerPos;
            WorldBuilder worldBuilder = new(this);
            world = worldBuilder.GenTiles();
            playerPos = worldBuilder.PlayerPos;

            player = new Player(playerPos[0], playerPos[1]);
        }

        public Tile GetTile(int _x, int _y) => world[_x, _y];

        public int GetSize(int _dimention) => world.GetLength(_dimention);
    }
}
