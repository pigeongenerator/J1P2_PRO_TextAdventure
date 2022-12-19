using J1P2_PRO_TextAdventure.GameScripts;

namespace J1P2_PRO_TextAdventure;

/// <summary>
/// 
/// </summary>
internal class Dialogue : IGameScript
{
    private readonly string[] dialogueLines;
    Game game;
    private int line;
    private int column;

    /// <summary>
    /// set's the line the prompt should appear at
    /// </summary>
    public int Line
    {
        get { return line; }
        set { line = value; }
    }

    /// <summary>
    /// set's what column the prompt should appear at
    /// </summary>
    public int Column
    {
        get { return column; }
        set { column = value; }
    }


    /// <summary>
    /// is used to create dialogue prompts
    /// </summary>
    /// <param name="_game">the current running game</param>
    /// <param name="_dialogueLines">set's the lines of the dialogue</param>
    public Dialogue(Game _game, params string[] _dialogueLines)
    {
        dialogueLines = _dialogueLines;
        game = _game;
    }

    /// <summary>
    /// starts the dialogue sequence
    /// </summary>
    public void Start()
    {
        Console.CursorVisible = false;

        WriteAt("[next]", line + 1, column + 1, true);

        foreach (string dialogueLine in dialogueLines)
        {
            WriteAt(dialogueLine, line, column);
            Console.ReadKey(true);
        }

        Console.CursorVisible = true;
        Console.Clear();
    }

    /// <summary>
    /// writes at a curtain position
    /// </summary>
    /// <param name="_value">sets the value to be written</param>
    /// <param name="_line">sets the line what should be written an</param>
    /// <param name="_column">sets the column that should be written at</param>
    private void WriteAt(string _value, int _line, int _column, bool _flipColors = false)
    {
        game.ClearLine(_line);
        Console.SetCursorPosition(_line, _column);

        if (_flipColors)
            FlipColors();

        Console.Write(_value);

        if (_flipColors)
            FlipColors();
    }

    /// <summary>
    /// flips the console's foreground and background colors
    /// </summary>
    private void FlipColors()
    {
        ConsoleColor originalForeground = Console.ForegroundColor;
        ConsoleColor originalBackground = Console.BackgroundColor;

        Console.ForegroundColor = originalBackground;
        Console.BackgroundColor = originalForeground;
    }
}
