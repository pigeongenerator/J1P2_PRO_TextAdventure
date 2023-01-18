using System.ComponentModel;
using System.Net.Http.Headers;

namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class WorldBuilder
    {
#warning test rectangular size
        private const int sizeX = 7; //defines a constant variable
        private const int sizeY = 7;
        private readonly int[] startPos;

        public int[] StartPos { get => startPos; }


        public WorldBuilder()
        {
            startPos = new int[2]; //defines an array with two position
        }

        /// <summary>
        /// generates the tiles based on <see cref="GetTileTypes"/>
        /// </summary>
        /// <returns>a 2D tile array</returns>
        public Tile[,] GenTiles()
        {
            int newX, newY; //declares newX and newY
            Tile[,] tiles; //declares a tile array
            TileType[,] types; //declares a type array
            List<(int x, int y)> foodLocations = new(); //defines a tuple list

            tiles = new Tile[sizeY, sizeX]; //assigns a new tile array with the size of sizeX & sizeY
            types = GetTileTypes(); //gets the tile types

            for (int x = 0; x < sizeX; x++) //loops through the X axis
            {
                for (int y = 0; y < sizeX; y++) //loops through the Y axis
                {
                    //converting x & y to flip x and y and flip y
                    newX = y;
                    newY = Math.Abs(x - sizeX) - 1; //removes 'size' from X, makes the value absolute (-x -> x || x -> x)

                    tiles[newX, newY] = new Tile(types[x, y]); //sets the tiles 

                    if (types[x, y] == TileType.start) //if the tile at x & y is start
                    {
                        startPos[0] = newX; //sets the start location
                        startPos[1] = newY;
                    }
                    else if (types[x, y] == TileType.food) //if the tile at x & y is food
                    {
                        foodLocations.Add((newX, newY)); //adds the location to the list
                    }
                }
            }

            SetFood(foodLocations, tiles); //sets the food locations

            return tiles;
        }

        /// <summary>
        /// selects a random food location and replaces the surrounding grass & remaining food tiles to grass
        /// </summary>
        /// <param name="_foodLocations">the food locations</param>
        /// <param name="_tiles">the 2D tile array</param>
        private void SetFood(List<(int x, int y)> _foodLocations, Tile[,] _tiles)
        {
            int foodIndex, x, y; //declares in variables
            (int x, int y) foodLocation;
            Random random = new();

            foodIndex = random.Next(_foodLocations.Count); //select random int based on list length
            foodLocation = _foodLocations[foodIndex]; //stores the location in a variable
            x = foodLocation.x; //gets the x value in the tuple
            y = foodLocation.y;

            //set other food tiles to grass
            foreach ((int x, int y) location in _foodLocations)
            {
                int foodX, foodY;

                if (location == foodLocation)
                {
                    continue;
                }

                foodX = location.x;
                foodY = location.y;
                _tiles[foodX, foodY].CastTile(TileType.grass); //changes the tile type to grass
            }

            for (int i = -1; i < 2; i += 2) //loops so an int is -1 and then 1
            {
                if (x + i >= 0 && x + i < sizeX) //if the modified position is between the bounds of the array
                {
                    _tiles[x + i, y].CastTile(TileType.water, TileType.grass); //changes the tile's type to water if the tile's type is grass
                }

                if (y + i >= 0 && y + i < sizeY)
                {
                    _tiles[x, y + i].CastTile(TileType.water, TileType.grass);
                }
            }
        }

        /// <summary>
        /// gets the tile types
        /// </summary>
        /// <returns>a 2D tile array with correct types</returns>
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
