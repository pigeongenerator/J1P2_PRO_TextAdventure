namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class WorldBuilder
    {
        private readonly int[] playerPos;

#warning look for better solution.
        public int[] PlayerPos { get { return playerPos; } }


        public WorldBuilder(World _world)
        {
            playerPos = new int[2] { 0, 0 };
        }

        public Tile[,] GenTiles()
        {
            const int size = 5;

            Random random = new();
            Tile[,] tiles = new Tile[size, size];
            TileType[,] types = new TileType[size, size]
            {
                { TileType.shrubbery,   TileType.shrubbery, TileType.shrubbery, TileType.shrubbery, TileType.shrubbery },
                { TileType.shrubbery,   TileType.tree,      TileType.tree,      TileType.shrubbery, TileType.shrubbery },
                { TileType.mountain,    TileType.start,     TileType.grass,     TileType.axe,       TileType.shrubbery },
                { TileType.tree,        TileType.grass,     TileType.tree,      TileType.water,     TileType.shrubbery },
                { TileType.shrubbery,   TileType.shrubbery, TileType.water,     TileType.food,      TileType.shrubbery }
            };

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
#warning make min 3 spots where the food may appear at and randomly select one of them
                    tiles[x, y] = new Tile(types[y, x]);

                    if (types[y, x] == TileType.start)
                    {
                        playerPos[0] = x;
                        playerPos[1] = y;
                    }
                }
            }

            return tiles;
        }
    }
}
