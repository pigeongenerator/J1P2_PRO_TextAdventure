namespace J1P2_PRO_TextAdventure;

/// <summary>
/// 
/// </summary>
internal class Dialogue : IGameScript
{
    private readonly string[] dialogueLines;
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
    /// <param name="_dialogueLines">set's the lines of the dialogue</param>
    public Dialogue(params string[] _dialogueLines)
    {
        dialogueLines = _dialogueLines;
    }

    /// <summary>
    /// starts the dialogue sequence
    /// </summary>
    public void Start()
    {
        WriteAt("[next]", line + 1, column + 1, true);

        foreach (string dialogueLine in dialogueLines)
        {
            WriteAt(dialogueLine, line, column);
            Console.ReadKey(true);
        }
    }

    /// <summary>
    /// writes at a curtain position
    /// </summary>
    /// <param name="_value">sets the value to be written</param>
    /// <param name="_line">sets the line what should be written an</param>
    /// <param name="_column">sets the column that should be written at</param>
    private void WriteAt(string _value, int _line, int _column, bool _flipColors = false)
    {
        ClearLine(_line);
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

    /// <summary>
    /// clears a line
    /// </summary>
    /// <param name="_line">sets the line to be cleared</param>
    /// <param name="_spaces">sets amount of spaces to be cleared</param>
    private void ClearLine(int _line)
    {
        Console.SetCursorPosition(_line, 0);
        Console.Write(new string(' ', Console.BufferWidth));
    }
}
