namespace J1P2_PRO_TextAdventure.GameScripts.Loops
{
    internal class InputLoop : Loop
    {
        private string? input;
        int originColumn, originRow;


        /// <summary>
        /// gets the input, if no input was given <see cref="InvalidOperationException"/> is called
        /// </summary>
        /// <returns>the input</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetInput()
        {
            if (input == null)
            {
                throw new InvalidOperationException("You need to run the loop before getting the input!");
            }

            return input.Trim().ToLower(); //formats input by removing spaces to the left & right and making it lowercase.
        }

        protected override void OnStart()
        {
            (int column, int row) originPos;

            Console.WriteLine("\nWhat do you want to do?");
            Console.Write(" > ");
            originPos = Console.GetCursorPosition();

            originRow = originPos.row;
            originColumn = originPos.column;
        }

        //as long that input is null or empty, the loop will loop
        protected override bool LoopCondition()
        {
            return string.IsNullOrEmpty(input);
        }

        //gets input from the user
        protected override void DuringLoop()
        {
            Console.SetCursorPosition(originColumn, originRow);
            input = Console.ReadLine(); //gets input from the user and stores it in a variable
        }

        //removes the '>' from the prompt because the user is no longer giving input
        protected override void OnEnd()
        {
            Console.SetCursorPosition(originColumn - 2, originRow);
            Console.WriteLine(' ');
        }
    }
}
