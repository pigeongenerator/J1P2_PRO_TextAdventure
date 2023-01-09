using J1P2_PRO_TextAdventure.GameScripts.Loops;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class Game : GameScript
    {
        protected override void Script()
        {
            if ( !RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new PlatformNotSupportedException($"the platform {RuntimeInformation.OSDescription} is not supported, sorry!");
            }

            MainLoop mainLoop = new();

            Welcome();
            mainLoop.Start();
        }

        /// <summary>
        /// shows the game's title.
        /// </summary>
        [SupportedOSPlatform("windows")]
        private void Welcome()
        {
            Console.Title = "Jesse and the terrible crash of the recreational vehicle" +
                ": the survival outside civilization underneath the great crystal blue sky";
            Console.SetBufferSize(135, Console.WindowHeight);
            Console.SetWindowSize(135, Console.WindowHeight);

            WriteFromFile("./ASCII/title.txt"); 

            ConsoleColor bgColor = Console.BackgroundColor;
            Console.BackgroundColor = Console.ForegroundColor;
            Console.ForegroundColor = bgColor;

            Console.WriteLine("<press any key to start>");
            Console.ResetColor();

            Console.CursorVisible = false;

            Console.ReadKey(true);

            Console.CursorVisible = true;
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
