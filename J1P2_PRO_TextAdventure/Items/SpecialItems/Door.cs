namespace J1P2_PRO_TextAdventure.Items.SpecialItems
{
    internal class Door : Item
    {
        private int[] exitAt;
        private bool isLocked;
        private readonly int? keyId;

        public bool IsLocked { get { return isLocked; } }
        public int[] ExitAt { get { return exitAt; } }


        /// <summary>
        /// defines a door
        /// </summary>
        /// <param name="_doorName">sets the name of the door</param>
        /// <param name="_exitX">sets the X exit location of the door</param>
        /// <param name="_exitY">sets the Y exit location of the door</param>
        public Door(string _doorName, int _exitX, int _exitY) : base($"{_doorName} door", new ItemBuilder().SetOnEat("you were unable to rip the door off of it's hinges"))
        {
            exitAt = new int[2];
            exitAt[0] = _exitX;
            exitAt[1] = _exitY;

            isLocked = false;
            keyId = null;
        }

        /// <summary>
        /// defines a locked door
        /// </summary>
        /// <param name="_doorName">sets the name of the door</param>
        /// <param name="_exitX">sets the X exit location of the door</param>
        /// <param name="_exitY">sets the Y exit location of the door</param>
        /// <param name="_keyId">sets the ID of the key used to open the door</param>
        public Door(string _doorName, int _exitX, int _exitY, int _keyId) : base($"locked {_doorName} door", new ItemBuilder().SetOnEat("you were unable to rip the door off of it's hinges"))
        {
            exitAt = new int[2];
            exitAt[0] = _exitX;
            exitAt[1] = _exitY;

            isLocked = true;
            keyId = _keyId;
        }

        /// <summary>
        /// gets the prompt that should play when using
        /// </summary>
        /// <returns>a prompt based on <see cref="IsLocked"/></returns>
        public override string OnUse()
        {
            if ( isLocked )
            {
                return "you can't open locked doors!";
            }

            return "you opened the door & went through it.";
        }
    }
}
