using J1P2_PRO_TextAdventure.Assets.Items.SpecialItems;
using J1P2_PRO_TextAdventure.Assets.Items;

namespace J1P2_PRO_TextAdventure.Assets.Rooms
{
    internal class RoomBuilder
    {
        private DoorItem roomDoor;
        private List<Item> roomItems;

        public DoorItem RoomDoor { get { return roomDoor; } }
        public List<Item> RoomItems { get { return roomItems; } }


        /// <summary>
        /// is used to build a room to make code more uniform
        /// </summary>
        public RoomBuilder(DoorItem _door)
        {
            roomDoor = _door;
            roomItems = new List<Item>();
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
