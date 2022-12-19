using J1P2_PRO_TextAdventure.Assets;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class GameItems
    {
        private Dictionary<string, Item> items;

        private readonly Item cookieItem = new Item("cookie", "you ate the delicious cookie and gained weight").Eatable();
        private readonly Item broomItem = new Item("broom", "after a lot of effort and gagging you were able to push the broom down your throat.", "you don't know how to do this", "you started sweeping the floor, now it is less dirty").Eatable();


        public GameItems()
        {
            items = new Dictionary<string, Item>
            {
                { cookieItem.Name, cookieItem },
                { broomItem.Name, broomItem }
            }; ;
        }

        public Item GetItem(string _itemName)
        {
            if (items.ContainsKey(_itemName) == false)
                throw new Exception($"the item {nameof(_itemName)} does not exist.");

            return items[_itemName];
        }
    }
}
