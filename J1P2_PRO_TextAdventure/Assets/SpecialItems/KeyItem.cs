using System.Diagnostics;

namespace J1P2_PRO_TextAdventure.Assets.SpecialItems
{
    internal class KeyItem : Item
    {
        private readonly (int row, int column) doorPosition;
        private readonly Workshop workshop;

        public KeyItem(int _row, int _column, Workshop _workshop) : base("key", "You it would be a bad idea to eat this")
        {
            doorPosition.row = _row;
            doorPosition.column = _column;
            workshop = _workshop;
        }

        public override string OnUse()
        {
            DoorItem door = workshop.GetRoom(doorPosition.row, doorPosition.column).Door;


            Debug.WriteLine($"unlocked door {nameof(door)}, at position {doorPosition}");

            return door.Unlock();
        }
    }
}
