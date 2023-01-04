using J1P2_PRO_TextAdventure.Items;

namespace J1P2_PRO_TextAdventure
{
    /// <summary>
    /// container for <see cref="Item"/>
    /// </summary>
    internal class ItemContainer
    {
        private readonly List<Item> items;


        /// <summary>
        /// creates a container to store <see cref="Item"/>
        /// </summary>
        public ItemContainer()
        {
            items = new List<Item>();
        }

        /// <summary>
        /// adds <see cref="Item"/> to the container
        /// </summary>
        /// <param name="_item">the item to be added</param>
        public void AddItemToContainer(Item _item)
        {
            items.Add(_item);
        }

        /// <summary>
        /// checks if the container has an item that matches the given name
        /// </summary>
        /// <param name="_itemName">sets the name of the item to search for</param>
        /// <returns>true if a matching item was found, false if it is not.</returns>
        public bool HasItem(string _itemName)
        {
            int itemIndex = GetItemIndex(_itemName);
            if ( itemIndex < 0 )
                return false;

            return true;
        }

        /// <summary>
        /// Gets the item that matches the name. If the item is not found, an exception is thrown
        /// </summary>
        /// <param name="_itemName">the name of the item to search for</param>
        /// <returns>The first matching item in the container</returns>
        /// <exception cref="Exception"></exception>
        public Item GetItem(string _itemName)
        {
            int itemIndex = GetItemIndex( _itemName);
            if ( itemIndex < 0 )
                throw new Exception($"the container does not contain item {_itemName}");

            return items[itemIndex];
        }

        /// <summary>
        /// gets the index of an item based on it's name
        /// </summary>
        /// <param name="_itemName">the name of the item to search for</param>
        /// <returns>-1 if no matching item was found, otherwise the index of the first item in the list</returns>
        private int GetItemIndex(string _itemName)
        {
            for ( int i = 0; i < items.Count; i++ )
            {
                if ( items[i].Name == _itemName )
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
