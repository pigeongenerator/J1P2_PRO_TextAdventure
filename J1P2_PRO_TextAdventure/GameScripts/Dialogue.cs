using System.ComponentModel.DataAnnotations;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    /// <summary>
    /// used for creating & going through dialogue chains
    /// </summary>
    internal class Dialogue : GameScript
    {
        private readonly string[] dialogueLines;
        private string continuePrompt;
        private int indent;

        /// <summary>
        /// the prompt that appears when asked to continue.
        /// </summary>
        public string ContinuePrompt
        {
            get { return continuePrompt; }
            set { continuePrompt = value; }
        }

        /// <summary>
        /// sets the amount of spaces the dialogue should be from the edge
        /// </summary>
        public void SetIndent(int _value)
        {
            indent = _value;
        }


        /// <summary>
        /// initializes a dialogue object
        /// </summary>
        /// <param name="_dialogueLines">sets the lines of the dialogue chain</param>
        public Dialogue(params string[] _dialogueLines)
        {
            dialogueLines = _dialogueLines;
            continuePrompt = "<press any key to continue>";
            indent = 1;
        }

        protected override void Script()
        {
            //Console.CursorVisible = false;

            foreach ( string line in dialogueLines )
            {
                Console.WriteLine(new string(' ', indent) + line);


                Console.Write(new string(' ', indent));
                (Console.ForegroundColor, Console.BackgroundColor) = (Console.BackgroundColor, Console.ForegroundColor); //flip's the console's foreground and background colors
                Console.Write(continuePrompt);


                Console.ReadKey(true);

                Console.ResetColor();
                ClearLine();
            }

            Console.CursorVisible = true;
        }

        private void ClearLine()
        {
            (int column, int row) = Console.GetCursorPosition();

            Console.SetCursorPosition(0, row);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, row);
        }
    }
}
