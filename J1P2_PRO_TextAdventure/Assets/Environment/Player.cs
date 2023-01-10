namespace J1P2_PRO_TextAdventure.Assets.Environment
{
    internal class Player
    {
        private readonly int[] pos;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">the x position of the player</param>
        /// <param name="y">the y position of the player</param>
        public Player(int _x, int _y)
        {
            pos = new int[2] { _x, _y }; //assigns an array with the size of 2 and the parameters x, y to the variable
        }

        /// <summary>
        /// moves the player relative to the player
        /// </summary>
        /// <param name="_dX">distance of the new player position in the x direction</param>
        /// <param name="_dY">distance of the new player position in the y direction</param>
        private void MoveRelative(int _dX, int _dY) { }
    }
}
