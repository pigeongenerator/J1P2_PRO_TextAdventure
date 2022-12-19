namespace J1P2_PRO_TextAdventure.Assets
{
    internal class Item
    {
        private readonly string name;
        private readonly string onEat;
        private readonly string onOpen;
        private readonly string onUse;
        private bool isEatable;
        private bool isUsable;
        private bool isUsableOnItem;

        public string Name { get { return name; } }
        public bool IsEatable { get { return isEatable; } }
        public bool IsUsable { get { return isUsable; } }
        public bool IsUsableOnItem { get { return isUsableOnItem; } }


        public Item(string _name, string _onEat = "you don't know how to do this", string _onOpen = "you don't know how to do this", string _onUse = "you don't know how to do this")
        {
            name = _name;
            onEat = _onEat;
            onOpen = _onOpen;
            onUse = _onUse;
            isEatable = false;
            isUsable = false;
            isUsableOnItem = false;
        }

        public Item Eatable()
        {
            isEatable = true;
            return this;
        }

        public Item Usable()
        {
            isUsable = true;
            return this;
        }

        public virtual string OnEat() => onEat;
        public virtual string OnOpen() => onOpen;
        public virtual string OnUse() => onUse;
    }
}
