namespace J1P2_PRO_TextAdventure.Environment
{
    internal abstract class Room
    {
        /// <summary>
        /// whether the room is locked or not
        /// </summary>
        public abstract bool IsLocked
        {
            get;
        }
        protected Tile[,] room;
        protected bool isGenerated = false;
        protected bool isHidden;

        public Room()
        {
            room = new Tile[0, 0];
        }

        /// <summary>
        /// Get's the tile's display character
        /// </summary>
        /// <returns>room's display character</returns>
        public virtual char GetDisplay()
        {
            if (isHidden == true)
            {
                return '.';
            }
            else
            {
                return ' ';
            }
        }

        /// <summary>
        /// generates the room
        /// </summary>
        protected void Generate()
        {
            if (isGenerated == true)
                throw new Exception("The room is already generated");
        }

        /// <summary>
        /// makes the player enter the room
        /// </summary>
        /// <param name="_playerEntityGuid">sets the GUID of the entity that is entering the room</param>
        public abstract void Enter(Guid _playerEntityGuid);
    }
}
