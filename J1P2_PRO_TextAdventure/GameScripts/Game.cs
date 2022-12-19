using J1P2_PRO_TextAdventure.GameScripts.Loops;
using J1P2_PRO_TextAdventure.Assets;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class Game : IGameScript
    {
        private readonly Item[] gameItems;
        private readonly MainLoop mainLoop;
        private readonly Welcome welcome;

        private readonly Item cookieItem = new Item("cookie", "you ate the delicious cookie and gained weight").Eatable();
        private readonly Item broomItem = new Item("broom", "after a lot of effort and gagging you were able to push the broom down your throat.", "you don't know how to do this", "you started sweeping the floor, now it is less dirty").Eatable();

        public Game()
        {
            mainLoop = new MainLoop();
            welcome = new Welcome();

            gameItems = new Item[]
            {
                cookieItem,
                broomItem
            };
        }

        public void Start()
        {
            welcome.Start();
            mainLoop.Start();
        }
    }
}
