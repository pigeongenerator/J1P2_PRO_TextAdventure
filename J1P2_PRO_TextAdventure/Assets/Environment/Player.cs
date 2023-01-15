namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class Player
    {
        private readonly int[] pos;
        private int wood;
        private bool hasAxe, hasBoat, isHungry, hasFood;

        public int Wood
        {
            get => wood;
            set => wood = value;
        }

        public bool HasAxe
        {
            get => hasAxe;
            set => hasAxe = value;
        }

        public bool HasBoat
        {
            get => hasBoat;
            set => hasBoat = value;
        }

        public bool IsHungry
        {
            get => isHungry;
            set => isHungry = value;
        }

        public bool HasFood
        {
            get => hasFood;
            set => hasFood = value;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">the x position of the player</param>
        /// <param name="y">the y position of the player</param>
        public Player(int _x, int _y)
        {
            pos = new int[2] { _x, _y }; //assigns an array with the size of 2 and the parameters x, y to the variable
            hasAxe = false;
            hasBoat = false;
            isHungry = true;
            hasFood = false;
        }

        /// <summary>
        /// tries to move the player relative to the current player, moving may fail if the tile moved to is not marked as passable
        /// </summary>
        /// <param name="_dX">distance of the new player position in the x direction</param>
        /// <param name="_dY">distance of the new player position in the y direction</param>
        public void Move(int _dX, int _dY, World _world)
        {
            int[] newPos = new int[2] { _dX + pos[0], _dY + pos[1] };
            Tile tileTryMovedTo;
            int x;
            int y;

            tileTryMovedTo = _world.GetTile(newPos[0], newPos[1]);

            x = newPos[0];
            y = newPos[1];

            if (tileTryMovedTo.CanEnter(this))
            {
                pos[0] = x;
                pos[1] = y;
            }
        }

        public (int x, int y) GetPosition()
        {
            return (pos[0], pos[1]);
        }
    }
}
