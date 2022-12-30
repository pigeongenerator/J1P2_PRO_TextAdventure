namespace J1P2_PRO_TextAdventure.Assets.Items.SpecialItems
{
    internal class DoorItem : Item
    {
        private readonly string doorName;
        private readonly (int row, int column) doorLeadsTo;
        private bool isLocked;
        private bool isOpen;

        public string DoorName { get { return doorName; } }
        public (int row, int column) DoorLeadsTo { get { return doorLeadsTo; } }
        public bool IsLocked { get { return isLocked; } }
        public bool IsOpen { get { return isOpen; } }


        public DoorItem(string _doorName, bool _isLocked, (int row, int column) _doorLeadsTo)
            : base("door", new ItemBuilder()
                  .SetCanTake(false)
                  .SetEatable(false, "You were unable to rip the door from it's hinges."))
        {
            doorName = _doorName;
            doorLeadsTo = _doorLeadsTo;
            isLocked = _isLocked;
        }

        public override string OnUse()
        {
            if ( isLocked == true )
            {
                return "It seems like this door is locked.";
            }

            if ( isOpen == false )
            {
                isOpen = true;
                return "You opened the door.";
            }
            else
            {
                return "This door is already open!";
            }
        }

        public string Unlock()
        {
            if ( isLocked == false )
                throw new Exception("the door is already unlocked!");

            string output;

            isLocked = false;
            output = "You unlocked the door with the key.";

            return output;
        }
    }
}
