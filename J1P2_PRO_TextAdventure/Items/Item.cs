namespace J1P2_PRO_TextAdventure.Items
{
    internal class Item
    {
        private readonly string name, onUse, onEat;
        private readonly bool usable, eatable, isHealthy;
        private readonly float weight;

        /// <summary>
        /// the item's name
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// whether the item is usable
        /// </summary>
        public bool Usable { get { return usable; } }

        /// <summary>
        /// whether the item is eatable
        /// </summary>
        public bool Eatable { get { return eatable; } }

        /// <summary>
        /// whether the item is healthy 
        /// </summary>
        public bool IsHealthy { get { return isHealthy; } }

        /// <summary>
        /// how heavy the item is
        /// </summary>
        public float Weight { get { return weight; } }


        public Item(string _itemName, ItemBuilder _itemBuilder)
        {
            name = _itemName;
            onUse = _itemBuilder.OnUse;
            onEat = _itemBuilder.OnEat;
            usable = _itemBuilder.Useable;
            eatable = _itemBuilder.Eatable;
            isHealthy = _itemBuilder.IsHealthy;
            weight = _itemBuilder.Weight;
        }

        /// <summary>
        /// runs code upon attempting to eat this item
        /// </summary>
        /// <returns>the prompt that should be played upon eating the item</returns>
        public virtual string OnEat() => onEat;

        /// <summary>
        /// runs code upon attempting to use this item
        /// </summary>
        /// <returns>the prompt that should be played upon using the item</returns>
        public virtual string OnUse() => onUse;
    }
}
