using J1P2_PRO_TextAdventure.GameScripts.Loops;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class Game : IGameScript
    {
        public void Start()
        {
            Workshop workshop = new();
            MainLoop mainLoop = new(workshop);


            mainLoop.Start();
        }
    }
}
