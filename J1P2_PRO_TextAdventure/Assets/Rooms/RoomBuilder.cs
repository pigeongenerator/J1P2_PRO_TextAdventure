using J1P2_PRO_TextAdventure.Assets.Items.SpecialItems;
using J1P2_PRO_TextAdventure.Assets.Items;

namespace J1P2_PRO_TextAdventure.Assets.Rooms
{
    /// <summary>
    /// gather's all data required for a room and put's it together
    /// </summary>
    internal class RoomBuilder
    {
        private const int maxDoors = 3;
        private List<DoorItem> roomDoors;
        private List<Item> roomItems;

        public List<DoorItem> RoomDoors { get { return roomDoors; } }
        public List<Item> RoomItems { get { return roomItems; } }


        /// <summary>
        /// builds a room
        /// </summary>
        public RoomBuilder()
        {
            roomDoors = new List<DoorItem>();
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

        /// <summary>
        /// adds a door to the room, cannot have more doors than <see cref="maxDoors"/>
        /// </summary>
        /// <param name="_door">set's the door to be added</param>
        /// <exception cref="Exception"></exception>
        public RoomBuilder AddDoor(DoorItem _door)
        {
            if ( roomDoors.Count >= maxDoors )
                throw new Exception($"a room cannot have more than {maxDoors} doors");
            roomDoors.Add(_door);
            return this;
        }
    }
}
