namespace J1P2_PRO_TextAdventure.GameScripts
{
    /// <summary>
    /// used for creating & going through dialogue chains
    /// </summary>
    internal class Dialogue : GameScript //inherits from GameScript
    {
        private readonly string[] dialogueLines; //declares a readonly variable which can only be assigned in the constructor
        private string continuePrompt; //declares a private string variable which means it can only be accessed in this class
        private int indent;

        /// <summary>
        /// the prompt that appears when asked to continue.
        /// </summary>
        public string ContinuePrompt //defines a property
        {
            get { return continuePrompt; } //is called upon getting a value from the property
            set { continuePrompt = value; } //is called upon assigning a value to the property
        }

        /// <summary>
        /// sets the amount of spaces the dialogue should be from the edge
        /// </summary>
        public void SetIndent(int _value)
        {
            if ( _value < 0 ) //runs the code below if _value is below 0
            { throw new ArgumentOutOfRangeException($"{nameof(_value)}", _value, $"{nameof(_value)} cannot be below 0"); } //throws an exception

            indent = _value; //assigns a value to a variable
        }


        /// <summary>
        /// initializes the dialogue object
        /// </summary>
        /// <param name="_dialogueLines">sets the lines of the dialogue chain</param>
        public Dialogue(params string[] _dialogueLines) //defines a constructor for the class Dialogue, the params keyword 
        {
            dialogueLines = _dialogueLines;
            continuePrompt = "<press any key to continue>";
            indent = 1;
        }

        protected override void Script()
        {
            Console.CursorVisible = false; //hides the cursor in the console output

            foreach ( string line in dialogueLines ) //loops through each item in the array
            {
                Console.WriteLine(new string(' ', indent) + line); //concatenates a value with the value of line


                Console.Write(new string(' ', indent)); //initializes a new string with a character repeated a curtain amount of times
                (Console.ForegroundColor, Console.BackgroundColor) = (Console.BackgroundColor, Console.ForegroundColor); //flip's the console's foreground and background colors using a tuple
                Console.Write(continuePrompt); //writes to console


                Console.ReadKey(true); //halts the thread until the user gives input, this input is intercepted to be empty

                Console.ResetColor(); //resets the console's color to be
                ClearLine(); //clears the current line on the console.
            }

            Console.CursorVisible = true;
        }

        /// <summary>
        /// clears the line of the current cursor's position
        /// </summary>
        private void ClearLine()
        {
            int row = Console.GetCursorPosition().Top; //gets what line the cursor is currently at

            Console.SetCursorPosition(0, row); //set's the cursor in the current line at position 0
            Console.Write(new string(' ', Console.BufferWidth)); //writes the space character over the entire width of the console
            Console.SetCursorPosition(0, row); //reset's the console's cursor position
        }
    }
}
