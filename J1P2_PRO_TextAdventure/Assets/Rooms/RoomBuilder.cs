using J1P2_PRO_TextAdventure.Assets.Items.SpecialItems;
using J1P2_PRO_TextAdventure.Assets.Items;

namespace J1P2_PRO_TextAdventure.Assets.Rooms
{
    internal class RoomBuilder
    {
        private List<DoorItem> roomDoors;
        private List<Item> roomItems;

        public List<DoorItem> RoomDoors { get { return roomDoors; } }
        public List<Item> RoomItems { get { return roomItems; } }


        /// <summary>
        /// is used to build a room to make code more uniform
        /// </summary>
        public RoomBuilder()
        {
            roomDoors = new List<DoorItem>();
            roomItems = new List<Item>();
        }

        /// <summary>
        /// adds a door to the room
        /// </summary>
        /// <param name="_door">the door to be added to the room</param>
        public RoomBuilder AddDoor(DoorItem _door)
        {
            RoomDoors.Add(_door);
            return this;
        }

        /// <summary>
        /// adds an item to the room
        /// </summary>
        /// <param name="_item">the item to be added to the room</param>
        public RoomBuilder AddItem(Item _item)
        {
            RoomItems.Add(_item);
            return this;
        }
    }
}
