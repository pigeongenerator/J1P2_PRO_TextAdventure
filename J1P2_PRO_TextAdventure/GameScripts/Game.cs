using J1P2_PRO_TextAdventure.GameScripts.Loops;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class Game : GameScript
    {
        protected override void Script()
        {
            

            MainLoop mainLoop = new();
            

            Welcome();
            mainLoop.Start();
        }

        /// <summary>
        /// shows the game's title.
        /// </summary>
        private void Welcome()
        {
            Dialogue dialogue;
            Random random = new();
            string[] dialogueLines = {
                "Jesse woke up today preparing for a trip to his family.",
                "Jesse stepped in the RV and drove off.",
                "The sight was beautiful here in the mountains.",
                "There were lakes and trees everywhere.",
                "While distracted, Jesse didn't see the tree he was about to crash into",
                "Suddenly, Jesse realized his impending doom.",
                "Without thinking Jesse jumped out of the RV",
                "However, he forgot that he was on a mountain and rolled off the cliff",
                "A few moments later Jesse heard the fiery explosion which used to be the RV",
                "Then Jesse passed out.",
                "When waking up, Jesse felt very hungry."
            };


            if ( random.Next(100) < 25 ) //returns true a curtain percentage of the time
            {
                dialogueLines[3] = "Then a potoo flew by.";
            }

            dialogue = new Dialogue(dialogueLines);

            ShowTitle();
            Console.Clear();
            dialogue.Start();
        }

        /// <summary>
        /// shows the game's title screen
        /// </summary>
        private void ShowTitle()
        {
            Dialogue dialogue = new("");
            dialogue.ContinuePrompt = "<press any key to start>";

            if ( !RuntimeInformation.IsOSPlatform(OSPlatform.Windows) )
            {
                throw new PlatformNotSupportedException($"the platform {RuntimeInformation.OSDescription} is not supported, sorry!");
            }

            Console.Clear();
            Console.Title = "Jesse and the terrible crash of the recreational vehicle" +
                ": the survival outside civilization underneath the great crystal blue sky";
            Console.SetBufferSize(135, Console.WindowHeight);
            Console.SetWindowSize(135, Console.WindowHeight);

            WriteFromFile("./ASCII/title.txt");

            dialogue.Start();
        }

        /// <summary>
        /// writes all the lines from a file to console
        /// </summary>
        /// <param name="_filePath">specifies the path that should be written from</param>
        private void WriteFromFile(string _filePath)
        {
            string[] titleLines = File.ReadAllLines(_filePath);
            string title = string.Empty;

            foreach ( string line in titleLines )
            {
                title += line + '\n';
            }

            Console.WriteLine(title);
        }
    }
}
