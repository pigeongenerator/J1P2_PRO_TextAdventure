namespace J1P2_PRO_TextAdventure.GameScripts
{
    /// <summary>
    /// 
    /// </summary>
    internal class Dialogue
    {
        private readonly string[] dialogueLines;

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
        /// <param name="_line">sets the line the prompt should appear at</param>
        /// <param name="_column">sets the column the prompt should appear at</param>
        public void Start(int _line, int _column)
        {
            WriteAt("[next]", _line + 1, _column + 1, true);

            foreach (string dialogueLine in dialogueLines)
            {
                WriteAt(dialogueLine, _line, _column);
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// writes a t a curtain position
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
}
