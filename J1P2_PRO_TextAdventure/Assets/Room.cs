using J1P2_PRO_TextAdventure.Assets.SpecialItems;

namespace J1P2_PRO_TextAdventure.Assets
{
    internal class Room
    {
        private readonly string name;
        private readonly DoorItem door;
        private readonly List<Item> items;

        public DoorItem Door { get { return door; } }
        public string Name { get { return name; } }
        public Item[] Items { get { return items.ToArray(); } }


        public Room(string _name, bool _isLocked, (int row, int column) _doorLeadsTo, params Item[] _items)
        {
            name = _name;
            door = new DoorItem(_isLocked, _doorLeadsTo);

            items = _items.ToList();
            items.Add(door);
        }

        /// <summary>
        /// adds a door to the room
        /// </summary>
        /// <returns>this object</returns>
        public Room AddDoor(bool _isLocked, (int row, int column) _doorLeadsTo)
        {
            throw new NotImplementedException();
        }

        public bool HasItem(string _itemName)
        {
            int index = GetItemIndex(_itemName);

            if (index == -1)
                return false;

            return true;
        }

        public Item GetItem(string _itemName)
        {
            int index = GetItemIndex(_itemName);

            if (index == -1)
                throw new Exception($"could not find this item, {_itemName}");

            return items[index];
        }

        public void RemoveItem(string _itemName)
        {
            int index = GetItemIndex(_itemName);

            if (index == -1)
                throw new Exception($"could not find this item, {_itemName}");

            items.RemoveAt(index);
        }

        /// <summary>
        /// gets the index of first the item with the item name, ignores doors
        /// </summary>
        /// <param name="_itemName">sets the name of the item to search</param>
        /// <returns>the index, -1 if no item was found</returns>
        private int GetItemIndex(string _itemName)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == _itemName && items[i].CanTake)
                    return i;
            }
            
            return -1;
        }
    }
}
