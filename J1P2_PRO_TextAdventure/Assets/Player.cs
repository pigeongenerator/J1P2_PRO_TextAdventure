using System.Diagnostics;
using J1P2_PRO_TextAdventure.Assets.Items;

namespace J1P2_PRO_TextAdventure.Assets
{
    internal class Player
    {
        private readonly List<Item> inventoryItems;
        private (int row, int column) position; //declares a tuple

        public Item[] InventoryItems { get { return inventoryItems.ToArray(); } }
        public (int row, int column) Position { get { return position; } }


        public Player(int _posX, int _posY)
        {
            inventoryItems = new List<Item>();
            position.row = _posX;
            position.column = _posY;
        }

        /// <summary>
        /// moves the player
        /// </summary>
        /// <param name="_position">set's the position that the player should move to</param>
        /// <param name="_workshop">set's the workshop to check</param>
        public void MoveTo(int _row, int _column, Workshop _workshop)
        {
            (int width, int height) = _workshop.GetSize();

            if ( _row < 0 || _row >= height )
            {
                _row = position.row;
            }

            if ( _column < 0 || _column >= width )
            {
                _column = position.column;
            }

            position.row = _row;
            position.column = _column;

            Debug.WriteLine($"Player was moved! new position: {position}");
        }

        /// <summary>
        /// adds an item to the inventory
        /// </summary>
        /// <param name="_item">set's the item to be added</param>
        public void AddToInventory(Item _item)
        {
            inventoryItems.Add(_item);
        }

        /// <summary>
        /// get's the first item with the specified name
        /// </summary>
        /// <param name="_itemName">set's the name of the item that will be searched for</param>
        /// <returns>the item</returns>
        public Item GetItem(string _itemName)
        {
            int index = GetItemIndex(_itemName);

            if ( index == -1 )
                throw new Exception($"could not find this item {_itemName}");

            return inventoryItems[index];
        }

        /// <summary>
        /// removes the item
        /// </summary>
        public void RemoveItem(Item _item)
        {
            inventoryItems.Remove(_item);
        }

        /// <summary>
        /// checks if the player has an item
        /// </summary>
        /// <param name="_itemName">set's the name of the item to search for</param>
        /// <returns>true if an item was found, false if it was not</returns>
        public bool HasItem(string _itemName)
        {
            if ( GetItemIndex(_itemName) == -1 )
            { return false; }

            return true;
        }

        private int GetItemIndex(string _itemName)
        {
            for ( int index = 0; index < inventoryItems.Count; index++ )
            {
                if ( inventoryItems[index].ItemName == _itemName )
                {
                    return index;
                }
            }

            return -1;
        }
    }
}
