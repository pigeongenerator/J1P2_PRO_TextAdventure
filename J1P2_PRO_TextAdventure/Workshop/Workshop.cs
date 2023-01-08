using J1P2_PRO_TextAdventure.Items;
using J1P2_PRO_TextAdventure.Rooms;
using System.ComponentModel.Design;

namespace J1P2_PRO_TextAdventure.Workshop
{
    internal class Workshop
    {
        public Workshop()
        {
            GameObjects gameObjects = new();
        }

        /// <summary>
        /// generates the workshop.
        /// </summary>
        /// <param name="_rows">specifies the amount of rows the array should have</param>
        /// <param name="_columns">specifies the amount of columns the array should have</param>
        /// <returns>a 2D array with all the rooms and items.</returns>
        private Room[,] Generate(int _rows, int _columns)
        {
            Room[,] rooms = new Room[_rows, _columns];

            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    if (rooms[row, column] == null)
                    {
                        rooms[row, column] = GenerateRoom();
                    }
                }
            }

            return rooms;
        }

        private Room GenerateRoom()
        {
            Generator<string> roomGenerator = new();
            Room room;


            return room;
        }

        private Item GenerateItem()
        {
        }
    }
}
