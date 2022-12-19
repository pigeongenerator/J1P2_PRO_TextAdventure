namespace J1P2_PRO_TextAdventure.Assets
{
    internal class Player
    {
        private readonly List<Item> inventory;
        private int positionX, positionY;

        public List<Item> Inventory { get { return inventory; } }


        public Player(int _posX, int _posY)
        {
            inventory = new List<Item>();
            positionX = _posX;
            positionY = _posY;
        }

        public (int posX, int posY) GetPlayerPos()
        {
            return (positionX, positionY);
        }

        public void MoveTo(int _posX, int _posY, Workshop _workshop)
        {
            (int width, int height) = _workshop.GetSize();

            if (_posX < 0 || _posX >= height)
            {
                _posX = positionX;
            }

            if (_posY < 0 || _posY >= width)
            {
                _posY = positionY;
            }

            if (_workshop.GetRoom(_posX, _posY).Door.IsLocked == false)
            {
                positionX = _posX;
                positionY = _posY;
            }
        }
    }
}
