namespace J1P2_PRO_TextAdventure.Assets
{
    internal class Player
    {
        private readonly List<Item> inventory;
        private (int row, int column) position; //declares a tuple

        public Item[] Inventory { get { return inventory.ToArray(); } }
        public (int row, int column) Position { get { return position; } }


        public Player(int _posX, int _posY)
        {
            inventory = new List<Item>();
            position.row = _posX;
            position.column = _posY;
        }

        /// <summary>
        /// moves the player
        /// </summary>
        /// <param name="_position">set's the position that the player should move to</param>
        /// <param name="_workshop">set's the workshop to check</param>
        public void MoveTo(int _row, int _column, Workshop _workshop)
        {
            (int width, int height) = _workshop.GetSize();

            if (_row < 0 || _row >= height)
            {
                _row = position.row;
            }

            if (_column < 0 || _column >= width)
            {
                _column = position.column;
            }

            if (_workshop.GetRoom(_row, _column).Door.IsLocked == false)
            {
                position.row = _row;
                position.column = _column;
            }
        }

        public void AddToInventory(Item _item)
        {
            inventory.Add(_item);
        }
    }
}
