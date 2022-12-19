using J1P2_PRO_TextAdventure.Environment;
using J1P2_PRO_TextAdventure.Environment.LivingEntities;
using J1P2_PRO_TextAdventure.GameScripts.Loops;

namespace J1P2_PRO_TextAdventure.GameScripts;

internal class Game : IGameScript
{
    private readonly PlayerEntity player;
    private readonly Workshop workshop;


    public Game()
    {
        workshop = new Workshop(this);
        player = workshop.GetPlayer();
    }

    /// <summary>
    /// starts the game
    /// </summary>
    public void Start()
    {
        Welcome welcome = new(this);
        MainLoop main = new(workshop, player, this);

        welcome.Start();
        main.Start();
    }

    public void WriteDialogue(string _value)
    {
        (int rows, int columns) = workshop.GetMaxSize();
        ClearLine(rows - 1);

        Console.SetCursorPosition(columns * 3 + 1, rows - 1);

        Console.Write(_value);
    }

    /// <summary>
    /// clears a line
    /// </summary>
    /// <param name="_line">sets the line to be cleared</param>
    public void ClearLine(int _line)
    {
        Console.SetCursorPosition(0, _line);
        Console.Write(new string(' ', Console.BufferWidth));
    }
}
