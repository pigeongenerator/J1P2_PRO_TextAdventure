using J1P2_PRO_TextAdventure.Environment;

namespace J1P2_PRO_TextAdventure.GameScripts.Loops;

internal class MainLoop : Loop
{
    private Workshop workshop;


    public MainLoop(Workshop _workshop)
    {
        workshop = _workshop;
    }

    protected override bool Check()
    {
        throw new NotImplementedException();
    }

    protected override void DoLoop()
    {
        UpdateDisplay();
        Console.ReadKey(true);
    }

    /// <summary>
    /// updates the display
    /// </summary>
    private void UpdateDisplay()
    {
        char[,] workshopRender = workshop.GetRender();
        string output = string.Empty;


        for (int x = 0; x < workshopRender.GetLength(0); x++)
        {
            for (int y = 0; y < workshopRender.GetLength(1); y++)
            {
                output += '|' + workshopRender[x,y].ToString();
            }
            output += "|\n";
        }

        Console.Clear();
        Console.WriteLine(output);
    }
}
