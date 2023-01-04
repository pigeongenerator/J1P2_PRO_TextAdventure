using J1P2_PRO_TextAdventure.Items.SpecialItems;

namespace J1P2_PRO_TextAdventure.Rooms
{
    internal class Room
    {
        private readonly string name;
        private readonly Door[] doors;
        private readonly ItemContainer items;

        public string Name { get { return name; }}
        public ItemContainer Items { get { return items; } }


        public Room(string _roomName, RoomBuilder _roomBuilder)
        {
            name = _roomName;
            doors = _roomBuilder.Doors;
            items = _roomBuilder.Items;
        }
    }
}
