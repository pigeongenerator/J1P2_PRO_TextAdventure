namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class Welcome : IGameScript
    {
        public void Start()
        {
            Console.WriteLine("you woke up on Christmas day and saw that there were no presents, " +
                "naturally you decided to eat to the north pole and break into Santa's house. " +
                "But he was nowhere to be found. It turned out that he had locked himself in his office.");
            Console.ReadKey(true);

        }
    }
}
