using J1P2_PRO_TextAdventure.GameScripts;
using System.Text;

namespace J1P2_PRO_TextAdventure //the "location" of this script
{

    internal class Program //defines a class
    {
        public static readonly bool skipDialogue = true;

        /// <summary>
        /// starts the program
        /// </summary>
        /// <param name="_args">the paths of the files the program is opened with</param>
        static void Main(string[] _args) //defines a static method which means that the method is accessible from anywhere the class is
        {
            Game game = new();
            game.Start();
        }
    }
}