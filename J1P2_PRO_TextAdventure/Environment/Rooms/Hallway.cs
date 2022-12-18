namespace J1P2_PRO_TextAdventure.Environment.Rooms
{
    internal class Hallway : Room
    {
        public Hallway(Item _item) : base(false)
        { }

        public override bool IsLocked
        {
            get { return false; }
        }

        public override void Enter()
        { }
    }
}
