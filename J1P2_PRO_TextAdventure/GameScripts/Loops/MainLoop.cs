using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.GameScripts.Loops
{
    internal class MainLoop : Loop
    {
        private World world;


        public MainLoop(World _world)
        {
            world = _world;
        }

        protected override void OnStart()
        {

        }

        protected override bool LoopCondition()
        {
            //throw new NotImplementedException();
            return true;
        }

        protected override void DuringLoop()
        {
            Console.WriteLine();
            string input = Prompt("What do you want to do?");

#warning please find a better solution for input
            if (input.StartsWith("go"))
            {
                if (input.EndsWith("north"))
                {
                    world.Player.Move(0, 1, world);
                }
                else if (input.EndsWith("east"))
                {
                    world.Player.Move(1, 0, world);
                }
                else if (input.EndsWith("south"))
                {
                    world.Player.Move(0, -1, world);
                }
                else if (input.EndsWith("west"))
                {
                    world.Player.Move(-1, 0, world);
                }
                else
                {
                    Console.WriteLine($" I do not know how to go to the \"{input}\"");
                }
            }
            else
            {
                Console.WriteLine($" I do not know how to do this thing: \"{input}\"");
            }
        }

        private string Prompt(string _message)
        {
            string? input;
            Console.WriteLine(' ' + _message);

            do
            {
                int row = Console.GetCursorPosition().Top;

                ClearLine();
                Console.Write(" > ");
                input = Console.ReadLine();

                if (input != null)
                {
                    input = input.Trim();
                }

                Console.SetCursorPosition(0, row);
            }
            while (string.IsNullOrEmpty(input));

            Console.WriteLine('-');

            return input;
        }

        /// <summary>
        /// clears the line of the current cursor's position
        /// </summary>
        private void ClearLine()
        {
#warning imported from Dialogue class, find a better solution.
            int row = Console.GetCursorPosition().Top; //gets what line the cursor is currently at

            Console.SetCursorPosition(0, row); //set's the cursor in the current line at position 0
            Console.Write(new string(' ', Console.BufferWidth)); //writes the space character over the entire width of the console
            Console.SetCursorPosition(0, row); //reset's the console's cursor position
        }
    }
}
