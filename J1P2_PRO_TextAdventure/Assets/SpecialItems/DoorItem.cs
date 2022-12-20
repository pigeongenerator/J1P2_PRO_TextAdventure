namespace J1P2_PRO_TextAdventure.Assets.SpecialItems
{
    internal class DoorItem : Item
    {
        private readonly KeyItem key;
        private readonly (int row, int column) leadsTo;
        private bool isLocked;
        private bool isOpen;

        public KeyItem Key { get { return key; } }
        public (int row, int column) LeadsTo { get { return leadsTo; } }
        public bool IsLocked { get { return isLocked; } }
        public bool IsOpen { get { return isOpen; } }

        public DoorItem(bool _isLocked, (int row, int column) _leadsTo) : base("door", "you were unable to remove the door from it's hinges.")
        {
            leadsTo = _leadsTo;
            isLocked = _isLocked;
            isOpen = false;
            CanTake = false;
        }

        public override string OnOpen()
        {
            if ( isLocked == true )
            {
                return "It seems like this door is locked.";
            }
            else if ( isOpen == false )
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
            string output;

            isLocked = false;
            output = "You opened the door with the key.";

            return output;
        }
    }
}
