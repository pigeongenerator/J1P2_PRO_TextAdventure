namespace J1P2_PRO_TextAdventure.Assets.Items
{
    internal class ItemBuilder
    {
        private bool canTake;
        private bool isEatable;
        private bool isUsable;
        private bool consumedOnUse;
        private string onEat;
        private string onUse;

        public bool CanTake { get { return canTake; } }
        public bool IsEatable { get { return isEatable; } }
        public bool IsUsable { get { return isUsable; } }
        public bool ConsumedOnUse { get { return consumedOnUse; } }
        public string OnEat { get { return onEat; } }
        public string OnUse { get { return onUse; } }


        /// <summary>
        /// aids building items to reduce code clutter
        /// </summary>
        public ItemBuilder()
        {
            canTake = false;
            isEatable = false;
            isUsable = false;
            onEat = onUse = "You don't know how to do this.";
        }

        /// <summary>
        /// set's the item's canTake.
        /// </summary>
        /// <param name="_canTake">set's if the item is able to be taken by the player or not</param>
        public ItemBuilder SetCanTake(bool _canTake)
        {
            canTake = _canTake;
            return this;
        }

        /// <summary>
        /// set's the item's eatable state
        /// </summary>
        /// <param name="_isEatable">set's whether the item is eatable or not</param>
        /// <param name="_onEat">set's the string that is written when attempting to eat this item</param>
        public ItemBuilder SetEatable(bool _isEatable, string _onEat)
        {
            isEatable = _isEatable;
            onEat = _onEat;
            return this;
        }

        /// <summary>
        /// set's the items usable state
        /// </summary>
        /// <param name="_isUsable">whether the item is usable</param>
        /// <param name="_consumedOnUse">whether the item is consumed on use</param>
        /// <param name="_onUse">set's the string that is outputted when using the item</param>
        public ItemBuilder SetUsable(bool _isUsable, bool _consumedOnUse, string _onUse)
        {
            isUsable = _isUsable;
            consumedOnUse = _consumedOnUse;
            onUse = _onUse;
            return this;
        }
    }
}
