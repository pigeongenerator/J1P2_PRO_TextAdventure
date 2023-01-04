using J1P2_PRO_TextAdventure.Items;
using J1P2_PRO_TextAdventure.Items.SpecialItems;

namespace J1P2_PRO_TextAdventure.Rooms
{
    internal class RoomBuilder
    {
        private List<Door> doors;
        private ItemContainer items;

        public Door[] Doors { get { return doors.ToArray(); } }
        public ItemContainer Items { get { return items; } }


        /// <summary>
        /// builds a room & organizes all the parameters in different builder methods
        /// </summary>
        public RoomBuilder()
        {
            doors = new List<Door>();
            items = new ItemContainer();
        }

        /// <summary>
        /// adds a door to the room
        /// </summary>
        /// <param name="_doorName">sets the name of the door (will be suffixed with " door")</param>
        /// <param name="_exitRow">sets the row where the door's exit is</param>
        /// <param name="_exitColumn">sets the column where the door's exit is</param>
        /// <returns>this</returns>
        public RoomBuilder AddDoor(string _doorName, int _exitRow, int _exitColumn)
        {
            Door door = new(_doorName, _exitRow, _exitColumn);
            doors.Add(door);

            return this;
        }

        /// <summary>
        /// adds a locked door to the room
        /// </summary>
        /// <param name="_doorName">sets the name of the door (will be prefixed with "locked " and suffixed with " door")</param>
        /// <param name="_exitRow">sets the row where the door's exit is</param>
        /// <param name="_exitColumn">sets the column where the door's exit is</param>
        /// <param name="_keyId">set's the id of the key used to unlock the door</param>
        /// <returns>this</returns>
        public RoomBuilder AddLockedDoor(string _doorName, int _exitRow, int _exitColumn, int _keyId)
        {
            Door door = new(_doorName, _exitRow, _exitColumn, _keyId);
            doors.Add(door);

            return this;
        }

        /// <summary>
        /// adds an item to the room
        /// </summary>
        /// <param name="_item">sets the item to be added to the room</param>
        /// <returns>this</returns>
        public RoomBuilder AddItem(Item _item)
        {
            items.AddItemToContainer(_item);
            return this;
        }
    }
}
