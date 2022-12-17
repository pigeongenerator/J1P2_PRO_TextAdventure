using J1P2_PRO_TextAdventure.Environment;

namespace J1P2_PRO_TextAdventure.GameScripts.Loops;

internal class MainLoop : Loop
{
    private Workshop workshop;


    public MainLoop(Workshop _workshop)
    {
        workshop = _workshop;
    }

    protected override bool CheckLoop()
    {
        return true;
        //throw new NotImplementedException();
    }

    protected override void DoLoop()
    {
        //UpdateDisplay();
        Console.ReadKey();
    }

    /// <summary>
    /// updates the display
    /// </summary>
    private void UpdateDisplay()
    {
        Console.Clear();
        char[,] workshopRender = workshop.GetRender();


        for (int x = 0; x < workshopRender.GetLength(0); x++)
        {
            for (int y = 0; y < workshopRender.GetLength(1); y++)
            {
                Console.Write('|' + workshopRender[x,y].ToString());
            }
            Console.WriteLine('|');
        }
    }
}
