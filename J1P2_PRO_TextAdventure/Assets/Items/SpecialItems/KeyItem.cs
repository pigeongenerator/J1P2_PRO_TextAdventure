using System.Diagnostics;

namespace J1P2_PRO_TextAdventure.Assets.Items.SpecialItems
{
    internal class KeyItem : Item
    {
        private readonly (int row, int column) doorPosition;
        private readonly Workshop workshop;

        public KeyItem(int _row, int _column, Workshop _workshop) : base("key", new ItemBuilder()
            .SetEatable(true, "You it would be a bad idea to eat this")
            .SetCanTake(true)
            .SetUsable(true, true, "null"))
        {
            doorPosition.row = _row;
            doorPosition.column = _column;
            workshop = _workshop;
        }

        public override string OnUse()
        {
            DoorItem door = workshop.GetRoom(doorPosition.row, doorPosition.column).RoomDoor;

            if (workshop.Player.Position != doorPosition)
            { return "You don't know where to use the key"; }

            Debug.WriteLine($"unlocked door {nameof(door)}, at position {doorPosition}");

            return door.Unlock();
        }
    }
}
