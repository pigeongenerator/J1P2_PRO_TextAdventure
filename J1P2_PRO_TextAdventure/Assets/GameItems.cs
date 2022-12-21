using J1P2_PRO_TextAdventure.Assets.Items;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class GameItems
    {
        private readonly Dictionary<string, Item> items;

        private readonly Item cookieItem = new("cookie", new ItemBuilder()
            .SetCanTake(true)
            .SetEatable(true, "You ate the delicious cookie"));

        private readonly Item broomItem = new("broom", new ItemBuilder()
            .SetCanTake(true)
            .SetEatable(true, "After a lot of gagging and choking, you managed to shove the broom down your throat.")
            .SetUsable(true, false, "You started to sweep the floor. The floor is less dirty now."));


        public GameItems()
        {
            items = new Dictionary<string, Item>
            {
                { cookieItem.ItemName, cookieItem },
                { broomItem.ItemName, broomItem }
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
