namespace J1P2_PRO_TextAdventure.Environment.Rooms
{
    internal class Start : Room
    {
        public override bool IsLocked
        {
            get { return false; }
        }

        public override void Enter()
        {
            Console.WriteLine("It seems like this is where you entered");
        }
    }
}
