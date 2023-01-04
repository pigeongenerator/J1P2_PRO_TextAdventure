namespace J1P2_PRO_TextAdventure.Items
{
    internal class ItemBuilder
    {
        private string onUse, onEat;
        private bool usable, eatable, isHealthy;
        private float weight;

        public string OnUse { get { return onUse; } }
        public string OnEat { get { return onEat; } }
        public bool Useable { get { return usable; } }
        public bool Eatable { get { return eatable; } }
        public bool IsHealthy { get { return isHealthy; } }
        public float Weight { get { return weight; } }


        /// <summary>
        /// builds an item & organizes all the parameters in different builder methods
        /// </summary>
        public ItemBuilder()
        {
            const string defaultPrompt = "you don't know how to do this.";

            weight = 0.0F;
            onEat = defaultPrompt;
            onUse = defaultPrompt;
            eatable = false;
            usable = false;
        }

        /// <summary>
        /// sets what happens when using the item
        /// </summary>
        /// <param name="_onUse"></param>
        /// <param name="_usable"></param>
        /// <returns>the current ItemBuilder object</returns>
        public ItemBuilder SetOnUse(string _onUse, bool _usable)
        {
            onUse = _onUse;
            usable = _usable;
            return this;
        }

        /// <summary>
        /// sets what happens on attempting to eat the item, overload where the item is eatable
        /// </summary>
        /// <param name="_onEat">sets the prompt displayed when attempting to eat the item</param>
        /// <param name="_weight">sets the item's weight</param>
        /// <param name="_isHealthy">sets if the item is healthy</param>
        /// <returns>the current ItemBuilder object</returns>
        public ItemBuilder SetOnEat(string _onEat, float _weight, bool _isHealthy)
        {
            onEat = _onEat;
            weight = _weight;
            isHealthy = _isHealthy;
            eatable = true;
            return this;
        }

        /// <summary>
        /// sets what happens on attempting to eat the item, default case where item is not eatable
        /// </summary>
        /// <param name="_onEat">sets the prompt displayed when attempting to eat the item</param>
        /// <returns>the current ItemBuilder object</returns>
        public ItemBuilder SetOnEat(string _onEat)
        {
            onEat = _onEat;
            weight = 0.0F;
            isHealthy = false;
            eatable = false;
            return this;
        }
    }
}
