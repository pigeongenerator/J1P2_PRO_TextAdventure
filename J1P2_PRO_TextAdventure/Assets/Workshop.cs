using J1P2_PRO_TextAdventure.Assets.SpecialItems;
using J1P2_PRO_TextAdventure.Assets.SpecialRooms;
using J1P2_PRO_TextAdventure.GameScripts;

namespace J1P2_PRO_TextAdventure.Assets
{
    internal class Workshop
    {
        private readonly GameItems gameItems;
        private readonly Room[,] rooms;
        private readonly Player player;

        public Player Player { get { return player; } }


        public Workshop(GameItems _gameItems)
        {
            gameItems = _gameItems;
            rooms = GenerateRooms();
            player = new(2, 1);
        }

        /// <summary>
        /// get's the size of the workshop
        /// </summary>
        /// <returns>the width and length of the workshop as a </returns>
        public (int width, int height) GetSize()
        {
            return (rooms.GetLength(1), rooms.GetLength(0));
        }

        /// <summary>
        /// Gets the room at a curtain position
        /// </summary>
        /// <param name="_row">sets the row the room should be got from</param>
        /// <param name="_column">sets the column the room should be got from</param>
        /// <exception cref="IndexOutOfRangeException" />
        /// <returns>the room at _row and _column</returns>
        public Room GetRoom(int _row, int _column)
        {
            if (_row < 0 || _row >= rooms.GetLength(0) ||
                _column < 0 || _column >= rooms.GetLength(1))
            {
                throw new IndexOutOfRangeException();
            }
            return rooms[_row, _column];
        }

        /// <summary>
        /// generates the rooms
        /// </summary>
        /// <returns>the rooms in a 2D array</returns>
        private Room[,] GenerateRooms()
        {
            KeyItem key = new(0, 0, this);

            Room[,] rooms = new Room[,]
            {
                { //row 0
                    new Room("broom closet", true, (0, 1), gameItems.GetItem("broom"), gameItems.GetItem("cookie")),
                    new Office(),
                    new Room("", false, (0, 0))
                },
                { //row 1
                    new Room("hallway", false, (0, 0), gameItems.GetItem("cookie"), gameItems.GetItem("cookie")),
                    new Room("hallway", false, (1, 0), key),
                    new Room("hallway", false, (1, 1))
                },
                { //row 2
                    new Room("", false, (0,0)),
                    new Room("entrance", false, (2, 2)),
                    new Room("hallway", false, (1, 2))
                }
            };

            return rooms;
        }
    }
}
