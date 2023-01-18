using System.Net.Http.Headers;

namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class WorldBuilder
    {
#warning test rectangular size
        private const int sizeX = 7;
        private const int sizeY = 7;
        private readonly int[] playerPos;

        public int[] StartPos { get => playerPos; }


        public WorldBuilder()
        {
            playerPos = new int[2] { 0, 0 };
        }

        public Tile[,] GenTiles()
        {
            int newX, newY;
            List<int[]> foodLocations = new();
            Tile[,] tiles;
            TileType[,] types;

            tiles = new Tile[sizeY, sizeX];
            types = GetTileTypes();

            for (int x = 0; x < sizeX; x++) //loops through the X axis
            {
                for (int y = 0; y < sizeX; y++) //loops through the Y axis
                {
                    newX = y;
                    newY = Math.Abs(x - sizeX) - 1; //removes 'size' from X, makes the value absolute (-x -> x || x -> x)

                    tiles[newX, newY] = new Tile(types[x, y]);

                    if (types[x, y] == TileType.start)
                    {
                        playerPos[0] = newX;
                        playerPos[1] = newY;
                    }
                    else if (types[x, y] == TileType.food)
                    {
                        foodLocations.Add(new int[] { newX, newY });
                    }
                }
            }

            SetFood(foodLocations, tiles);

            return tiles;
        }

        private void SetFood(List<int[]> _foodLocations, Tile[,] _tiles)
        {
            int foodIndex, x, y;
            int[] foodLocation;
            Random random = new();

            foodIndex = random.Next(_foodLocations.Count); //select random food tile
            foodLocation = _foodLocations[foodIndex];
            x = foodLocation[0];
            y = foodLocation[1];

            //set other food tiles to grass
            foreach (int[] location in _foodLocations)
            {
                int foodX, foodY;

                if (location == foodLocation)
                {
                    continue;
                }

                foodX = location[0];
                foodY = location[1];
                _tiles[foodX, foodY].CastTile(TileType.grass);
            }

            for (int i = -1; i < 2; i += 2)
            {
                if (x + i >= 0 && x + i < sizeX)
                {
                    _tiles[x + i, y].CastTile(TileType.water, TileType.grass);
                }
                if (y + i >= 0 && y + i < sizeY)
                {
                    _tiles[x, y + i].CastTile(TileType.water, TileType.grass);
                }
            }
        }

        private TileType[,] GetTileTypes()
        {
            return new TileType[sizeX, sizeY]
            {
                { TileType.shrubbery, TileType.shrubbery, TileType.shrubbery, TileType.shrubbery, TileType.shrubbery, TileType.shrubbery, TileType.shrubbery },
                { TileType.shrubbery, TileType.tree,      TileType.grass,     TileType.grass,     TileType.food,      TileType.grass,     TileType.shrubbery },
                { TileType.mountain,  TileType.start,     TileType.grass,     TileType.tree,      TileType.grass,     TileType.food,      TileType.shrubbery },
                { TileType.mountain,  TileType.grass,     TileType.tree,      TileType.grass,     TileType.grass,     TileType.grass,     TileType.shrubbery },
                { TileType.shrubbery, TileType.shrubbery, TileType.shrubbery, TileType.tree,      TileType.tree,      TileType.grass,     TileType.shrubbery },
                { TileType.shrubbery, TileType.axe,       TileType.tree,      TileType.grass,     TileType.grass,     TileType.food,      TileType.shrubbery },
                { TileType.shrubbery, TileType.shrubbery, TileType.shrubbery, TileType.shrubbery, TileType.shrubbery, TileType.shrubbery, TileType.shrubbery }
            };
        }
    }
}
