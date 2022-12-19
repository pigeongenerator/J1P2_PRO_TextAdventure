using J1P2_PRO_TextAdventure.Assets.SpecialItems;
using J1P2_PRO_TextAdventure.Assets.SpecialRooms;

namespace J1P2_PRO_TextAdventure.Assets
{
    internal class Workshop
    {
        private readonly Room[,] rooms;
        private readonly Dictionary<string, Item> gameItems;
        private readonly Player player;

        public Player Player { get { return player; } }


        public Workshop(Dictionary<string, Item> _gameItems)
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
                    new Room("hallway", false, gameItems["cookie"]),
                    office,
                    new Room("broom closet", false, gameItems["broom"], gameItems["cookie"])
                },
                { //row 1
                    new Room("hallway", false, (2, 1)),
                    new Room("hallway", false, (1, 0), office.Door.Key),
                    new Room("hallway", false, (0, 0))
                },
                { //row 2
                    new Room("hallway", false, (0, 0)),
                    new Room("start", false, (1, 1)),
                    new Room("hallway", false, (0, 0))
                }
            };
        }
    }
}
