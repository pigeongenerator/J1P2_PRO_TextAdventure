namespace J1P2_PRO_TextAdventure.Workshop
{
    /// <summary>
    /// selects a random item from a pool of items
    /// </summary>
    /// <typeparam name="_type">sets the type of the items the selector will select out of</typeparam>
    internal class Selector<_type>
    {
        private readonly List<_type> pool;


        public Selector()
        {
            pool = new List<_type>();
        }

        /// <summary>
        /// adds an item to the pool
        /// </summary>
        /// <param name="_item">the item to be added to the pool</param>
        public void AddToPool(_type _item)
        {
            pool.Add(_item);
        }

        /// <summary>
        /// selects a random item from the pool of items
        /// </summary>
        /// <returns>the item with the type of this</returns>
        /// <exception cref="Exception"></exception>
        public _type SelectItem()
        {
            if ( pool.Count <= 0 )
                throw new Exception($"there was nothing added to {nameof(pool)}!");

            Random random = new Random();
            int index = random.Next(0, pool.Count);

            return pool[index];
        }
    }
}
