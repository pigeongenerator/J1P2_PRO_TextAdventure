using J1P2_PRO_TextAdventure.Environment;
using J1P2_PRO_TextAdventure.Environment.LivingEntities;
using System.Diagnostics;

namespace J1P2_PRO_TextAdventure.GameScripts.Loops;

internal class MainLoop : Loop
{
    private readonly Workshop workshop;
    private readonly PlayerEntity player;
    private readonly Game game;


    public MainLoop(Workshop _workshop, PlayerEntity _player, Game _game)
    {
        workshop = _workshop;
        player = _player;
        game = _game;
    }

    protected override bool Check()
    {
        Debug.WriteLine("Passed MainLoop check, returning true.");
        return true;
    }

    protected override void DoLoop()
    {
        UpdateDisplay();

        GetInput();

        //! CONSOLE.CLEAR IN DIALOGUE
    }

    private void GetInput()
    {
        string? input;

        Console.Write(" > ");

        input = Console.ReadLine();

        if (string.IsNullOrEmpty(input) == false)
        {
            if (input.StartsWith("go"))
            {
                if (input.EndsWith("up"))
                {
                    player.MoveRelative(-1, 0, workshop); //move up
                }
                else if (input.EndsWith("down"))
                {
                    player.MoveRelative(1, 0, workshop); //move down
                }
                else if (input.EndsWith("left"))
                {
                    player.MoveRelative(0, -1, workshop); //move left
                }
                else if (input.EndsWith("right"))
                {
                    player.MoveRelative(0, 1, workshop); //move right
                }
            }
        }
    }

    /// <summary>
    /// updates the display
    /// </summary>
    private void UpdateDisplay()
    {
        char[,] workshopRender = workshop.GetRender();
        string output = string.Empty;
        (int maxRows, int maxColumns) = workshop.GetMaxSize();


        for (int x = 0; x < workshopRender.GetLength(0); x++)
        {
            for (int y = 0; y < workshopRender.GetLength(1); y++)
            {
                output += '|' + workshopRender[x, y].ToString();
            }
            output += "|\n";
        }


        game.ClearLine(maxRows + 1);

        Console.SetCursorPosition(0, 0);
        Console.Write(output);

        Console.SetCursorPosition(maxColumns * 3 + 1, 0);
        Console.Write($"BMI: {player.BMI}");

        Console.SetCursorPosition(0, maxRows + 1);
    }
}
