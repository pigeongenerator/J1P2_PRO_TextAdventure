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

        public Tile GetPlayerTile()
        {
            (int x, int y) = player.GetPosition();

            return GetTile(x, y);
        }

        public int GetSize() => world.GetLength(0); //world is a square
    }
}
