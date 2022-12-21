namespace J1P2_PRO_TextAdventure.Assets.Items
{
    internal class Item
    {
        private readonly string itemName;
        private readonly string onEat;
        private readonly string onUse;
        private bool canTake;
        private bool isEatable;
        private bool isUsable;
        private bool consumedOnUse;

        public string ItemName { get { return itemName; } }
        public bool IsEatable { get { return isEatable; } }
        public bool IsUsable { get { return isUsable; } }
        public bool ConsumedOnUse { get { return consumedOnUse; } }
        public bool CanTake
        {
            get { return canTake; }
            protected set { canTake = value; }
        }


        public Item(string _itemName, ItemBuilder _itemBuilder)
        {
            itemName = _itemName;
            onEat = _itemBuilder.OnEat;
            onUse = _itemBuilder.OnUse;
            isEatable = _itemBuilder.IsEatable;
            isUsable = _itemBuilder.IsUsable;
            canTake = _itemBuilder.CanTake;
            consumedOnUse = _itemBuilder.ConsumedOnUse;
        }

        public virtual string OnEat() => onEat;
        public virtual string OnUse() => onUse;
    }
}
