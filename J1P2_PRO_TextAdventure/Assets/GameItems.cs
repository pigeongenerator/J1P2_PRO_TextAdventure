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

        private readonly Item santaItem = new("santa", new ItemBuilder()
            .SetCanTake(false)
            .SetEatable(true, "you started chopping santa in little pieces to make it easier for your digestion. Then you started munching on the Santa meat, it almost tastes like a very, bloody steak."));

        private readonly Item elfItem = new("elf", new ItemBuilder()
            .SetCanTake(true)
            .SetEatable(true, "the little elf surprisingly went down with ease."));

        private readonly Item ar15Item = new("ar15", new ItemBuilder()
            .SetCanTake(true)
            .SetUsable(true, false, "you started blasting!"));

        private readonly Item presentItem = new("present", new ItemBuilder()
            .SetCanTake(true)
            .SetUsable(true, true, "you opened the present but sadly there was nothing in it but coal.")
            .SetEatable(true, "You ate the present and it strangely tasted like dust and dirt."));

        private readonly Item uraniumItem = new("uranium", new ItemBuilder()
            .SetCanTake(true)
            .SetEatable(true, "you feel sick after swallowing the uranium"));

        public GameItems()
        {
            items = new Dictionary<string, Item>
            {
                { cookieItem.ItemName,  cookieItem },
                { broomItem.ItemName,   broomItem },
                { santaItem.ItemName,   santaItem },
                { elfItem.ItemName,     elfItem },
                { ar15Item.ItemName,    ar15Item },
                { presentItem.ItemName, presentItem },
                { uraniumItem.ItemName, uraniumItem }
            }; ;
        }

        public Item GetItem(string _itemName)
        {
            if ( items.ContainsKey(_itemName) == false )
                throw new Exception($"the item {nameof(_itemName)} does not exist.");

            return items[_itemName];
        }
    }
}
