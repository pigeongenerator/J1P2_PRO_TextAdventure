using J1P2_PRO_TextAdventure.GameScripts;


namespace J1P2_PRO_TextAdventure.Environment.Rooms
{
    internal class Hallway : Room
    {
        public Hallway(Game _game) : base(_game, false)
        { }

        public override bool IsLocked
        {
            get { return false; }
        }

        public override void Enter()
        { }
    }
}
