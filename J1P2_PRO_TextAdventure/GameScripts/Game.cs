using J1P2_PRO_TextAdventure.Environment;
using J1P2_PRO_TextAdventure.GameScripts.Loops;

namespace J1P2_PRO_TextAdventure.GameScripts;

internal class Game : IGameScript
{
    private Workshop workshop;


    public Game()
    {
        workshop = new Workshop();
    }

    /// <summary>
    /// starts the game
    /// </summary>
    public void Start()
    {
        Welcome welcome = new();
        MainLoop main = new(workshop);

        welcome.Start();
        main.Start();
    }
}
