using J1P2_PRO_TextAdventure.GameScripts.Loops;
using J1P2_PRO_TextAdventure.Assets;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class Game : IGameScript
    {
        private readonly GameItems gameItems;

        private readonly Workshop workshop;
        private readonly Player player;

        private readonly MainLoop mainLoop;
        private readonly Welcome welcome;

        

        public Game()
        {
            gameItems = new GameItems();

            workshop = new Workshop(gameItems);
            player = workshop.Player;

            mainLoop = new MainLoop();
            welcome = new Welcome();
        }

        public void Start()
        {
            welcome.Start();
            mainLoop.Start();
        }
    }
}
