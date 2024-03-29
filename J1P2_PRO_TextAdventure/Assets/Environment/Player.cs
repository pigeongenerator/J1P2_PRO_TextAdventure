﻿namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class Player
    {
        private readonly int[] pos;
        private int wood;
        private bool hasAxe;
        private bool hasBoat;
        private bool isHungry;

        public int Wood { get { return wood; } set { wood = value; } }
        public bool HasAxe { get { return hasAxe; } set { hasAxe = value; } }
        public bool HasBoat { get { return hasBoat; } set { hasBoat = value; } }
        public bool IsHungry { get { return isHungry; } set { isHungry = value; } }


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
            IsHungry = true;
        }

        /// <summary>
        /// moves the player relative to the current player
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

            for (int i = 0; i < newPos.Length; i++)
            {
                if (newPos[i] < 0 || newPos[i] >= _world.GetSize(i))
                {
                    newPos[i] = pos[i];
                }
            }

            x = newPos[0];
            y = newPos[1];

#warning writing to console should only happen in the game, not in the assets.
            Console.WriteLine(' ' + tileTryMovedTo.OnEnter(this));

            if (tileTryMovedTo.CanEnter(this))
            {
                tileTryMovedTo.Enter(this);
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
