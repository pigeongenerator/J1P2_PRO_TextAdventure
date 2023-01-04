using J1P2_PRO_TextAdventure.Items;
using J1P2_PRO_TextAdventure.Items.SpecialItems;

namespace J1P2_PRO_TextAdventure
{
    internal class Player
    {
        float weight;
        private readonly int[] pos;
        private readonly ItemContainer inventory;

        public float Weight { get { return weight; } }
        public int[] Pos { get { return pos; } }
        public ItemContainer Inventory { get { return inventory; } }


        public Player(int _posX, int _posY)
        {
            weight = 77.0F;
            pos = new int[2];
            pos[0] = _posX;
            pos[1] = _posY;

            inventory = new ItemContainer();
        }

        /// <summary>
        /// tries to eat <see cref="Item"/> with a specified name from <see cref="inventory"/>.
        /// adds/subtracts <see cref="Item.Weight"/> to <see cref="Weight"/> depending on <see cref="Item.IsHealthy"/>
        /// if <see cref="Weight"/> is greater than or equal to <see cref="Item.Weight"/>
        /// </summary>
        /// <param name="_itemName">sets the name of the item to search for</param>
        /// <returns>the prompt that should be played when attempting to eat an item,</returns>
        public string TryEatItem(string _itemName)
        {
            if ( inventory.HasItem(_itemName) == false )
            {
                return $"You do not have this item, {_itemName}.";
            }

            Item item = inventory.GetItem(_itemName);
            if ( item.Weight > weight )
            {
                return $"{item.Name} is too heavy to be eaten.";
            }

            EatItem(item);

            return item.OnEat();
        }


        /// <summary>
        /// tries to go through a door, if <see cref="Door"/> is locked, the players position is updated.
        /// </summary>
        /// <param name="_door">sets the door the player should go through</param>
        /// <returns>the prompt that should be played when trying to go through the door</returns>
        public string TryGoThroughDoor(Door _door)
        {
            if ( _door.IsLocked == false )
            {
                pos[0] = _door.ExitAt[0];
                pos[1] = _door.ExitAt[1];
            }

            return _door.OnUse();
        }

        /// <summary>
        /// subtracts/adds <see cref="Item.Weight" to <see cref="Weight"/> depending on <see cref="Item.IsHealthy"/>
        /// </summary>
        /// <param name="_item"></param>
        private void EatItem(Item _item)
        {
            if ( _item.IsHealthy )
            {
                weight -= _item.Weight;
            }
            else
            {
                weight += _item.Weight;
            }
        }
    }
}
