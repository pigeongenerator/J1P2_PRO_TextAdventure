using J1P2_PRO_TextAdventure.GameScripts;

namespace J1P2_PRO_TextAdventure.Environment.Rooms
{
    internal class Start : Room
    {
        public override bool IsLocked
        {
            get { return false; }
        }


        public Start(Game _game) : base(_game, false)
        { }

        public override void Enter()
        {
            game.WriteDialogue("It seems like this is where you entered");
        }
    }
}
