namespace J1P2_PRO_TextAdventure.Assets.SpecialItems
{
    internal class KeyItem : Item
    {
        private readonly DoorItem door;

        public KeyItem(DoorItem _door) : base("key", "it would be a bad idea to eat this")
        {
            door = _door;
        }

        public override string OnUse()
        {
            return door.Unlock(this);
        }
    }
}
