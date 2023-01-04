using J1P2_PRO_TextAdventure.Items;
using J1P2_PRO_TextAdventure.Rooms;
using System.ComponentModel.Design;

namespace J1P2_PRO_TextAdventure.Workshop
{
    internal class Workshop
    {

        private Room[,] Generate(int _rows, int _columns)
        {
            Room[,] rooms = new Room[_rows, _columns];

            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    if (rooms[row, column] == null)
                    {

                    }
                }
            }

            return rooms;
        }

        private Room GenerateRoom()
        {


            return room;
        }

        private Item GenerateItem()
        {
            
        }
    }
}
