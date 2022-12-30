using J1P2_PRO_TextAdventure.Assets.Items;
using J1P2_PRO_TextAdventure.Assets.Items.SpecialItems;
using J1P2_PRO_TextAdventure.Assets.Rooms;

namespace J1P2_PRO_TextAdventure.Assets
{
    internal class Room
    {
        private readonly string roomName;
        private readonly DoorItem[] roomDoors;
        private readonly List<Item> roomItems;

        public string RoomName { get { return roomName; } }
        public DoorItem RoomDoor { get { return roomDoor; } }
        public Item[] RoomItems { get { return roomItems.ToArray(); } }


        public Room(string _roomName, RoomBuilder _roomBuilder)
        {
            roomName = _roomName;
            roomDoor = _roomBuilder.RoomDoor;
            roomItems = _roomBuilder.RoomItems;
            roomItems.Add(roomDoor);
        }

        public bool HasItem(string _itemName, bool _ignoreCanTake = false)
        {
            int index = GetItemIndex(_itemName, _ignoreCanTake);

            if (index == -1)
                return false;

            return true;
        }

        public Item GetItem(string _itemName, bool _ignoreCanTake = false)
        {
            int index = GetItemIndex(_itemName, _ignoreCanTake);

            if (index == -1)
                throw new Exception($"could not find this item, {_itemName}");

            return roomItems[index];
        }

        public void RemoveItem(string _itemName, bool _ignoreCanTake = false)
        {
            int index = GetItemIndex(_itemName, _ignoreCanTake);

            if (index == -1)
                throw new Exception($"could not find this item, {_itemName}");

            roomItems.RemoveAt(index);
        }

        /// <summary>
        /// gets the index of first the item with the item name, ignores doors
        /// </summary>
        /// <param name="_itemName">sets the name of the item to search</param>
        /// <returns>the index, -1 if no item was found</returns>
        private int GetItemIndex(string _itemName, bool _ignoreCanTake)
        {
            for (int i = 0; i < roomItems.Count; i++)
            {
                if (roomItems[i].ItemName == _itemName && (_ignoreCanTake || roomItems[i].CanTake))
                    return i;
            }
            
            return -1;
        }
    }
}
