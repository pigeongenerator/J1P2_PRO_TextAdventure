using J1P2_PRO_TextAdventure.Assets.SpecialRooms;

namespace J1P2_PRO_TextAdventure.Assets
{
    internal class Workshop
    {
        private readonly Room[,] rooms;
        private readonly Item[] gameItems;
        private readonly Player player;

        public Player Player { get { return player; } }


        public Workshop(Item[] _gameItems)
        {
            rooms = GenerateRooms();
            gameItems = _gameItems;
            player = new(1, 2);
        }

        public (int width, int height) GetSize()
        {
            return (rooms.GetLength(1), rooms.GetLength(0));
        }

        public Room GetRoom(int _roomPosX, int _roomPosY)
        {
            return rooms[_roomPosX, _roomPosY];
        }

        private Room[,] GenerateRooms()
        {
            Office office = new Office();

            return new Room[,]
            {
                { //row 0
                    new Room("hallway", false, gameItems[1]),
                    office,
                    new Room("broom closet", false, gameItems[0], gameItems[1])
                },
                { //row 1
                    new Room("hallway", false),
                    new Room("hallway", false, office.Door.Key),
                    new Room("hallway", false)
                },
                { //row 2
                    new Room("hallway", false),
                    new Room("start", false),
                    new Room("hallway", false)
                }
            };
        }
    }
}
