namespace J1P2_PRO_TextAdventure.GameScripts.Loops
{
    internal class InputLoop : Loop
    {
        private string? input;
        private readonly string message;


        public InputLoop(string _message)
        {
            message = _message;
        }

        public string GetInput()
        {
            if (input != null)
            {
                return input;
            }

            throw new InvalidOperationException("no input has been assigned yet! (start the loop before requesting the input)");
        }

        protected override void OnStart()
        {
            Console.WriteLine(' ' + message);
        }

        protected override bool LoopCondition()
        {
            return string.IsNullOrEmpty(input);
        }

        protected override void DuringLoop()
        {
            int row = Console.GetCursorPosition().Top; //gets what line the cursor is currently at

            ClearLine();
            Console.Write(" > ");

            /*Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("e.g. go to north");
            SetHorizontalCursorPos(3);
            Console.ResetColor();*/

            input = Console.ReadLine();

            if (input != null)
            {
                input = input.Trim();
            }

            Console.SetCursorPosition(1, row);
            Console.Write(' ');
        }

        protected override void OnEnd()
        {
            Console.WriteLine();
        }

#warning imported from Dialogue class, find a better solution.
        /// <summary>
        /// clears the line of the current cursor's position
        /// </summary>
        private void ClearLine()
        {
            SetHorizontalCursorPos(0); //set's the cursor in the current line at position 0
            Console.Write(new string(' ', Console.BufferWidth)); //writes the space character over the entire width of the console
            SetHorizontalCursorPos(0); //reset's the console's cursor position
        }

        /// <summary>
        /// sets the cursor's position on the horizontal axis
        /// </summary>
        /// <param name="_hPosition">the position on the horizontal axis</param>
        private void SetHorizontalCursorPos(int _hPosition)
        {
            int row = Console.GetCursorPosition().Top; //gets what line the cursor is currently at

            Console.SetCursorPosition(_hPosition, row);
        }
    }
}
