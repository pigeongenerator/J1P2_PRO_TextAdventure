namespace J1P2_PRO_TextAdventure.Assets.SpecialItems
{
    internal class DoorItem : Item
    {
        private readonly KeyItem key;
        private bool isLocked;
        private bool isOpen;

        public bool IsLocked { get { return isLocked; } }
        public KeyItem Key { get { return key; } }

        public DoorItem(bool _isLocked) : base("door", "the door is too big to be eaten")
        {
            isLocked = _isLocked;
            isOpen = false;
            key = new KeyItem(this);
        }

        public override string OnOpen()
        {
            if (isLocked == true)
            {
                return "It seems like this door is locked.";
            }
            else
            {
                isOpen = true;
                return "You opened the door.";
            }
        }

        public string Unlock(KeyItem _key)
        {
            string output;

            if (key == _key)
            {
                output = "You opened the door with the key.";
            }
            else
            {
                output = "This is the wrong key!";
            }

            return output;
        }
    }
}
