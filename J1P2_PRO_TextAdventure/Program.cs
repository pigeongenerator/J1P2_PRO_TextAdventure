using J1P2_PRO_TextAdventure.GameScripts;

namespace J1P2_PRO_TextAdventure // "location" of the script
{

    internal class Program //defines a class
    {
        public static void Main(string[] _args) //defines a static method
        {
            Game game = new(); //defines a new game object
            game.Start(); //starts the game
        }
    }
}