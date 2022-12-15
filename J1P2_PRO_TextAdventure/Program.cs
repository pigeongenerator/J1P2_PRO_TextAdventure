namespace J1P2_PRO_TextAdventure //the "location" of this script
{
    internal class Program //defines a class
    {
        private readonly Command[] commands = {
            new("go", new string[] { "north", "east", "south", "west", "back" })
        };


        static void Main(string[] _args) //defines a static method which means that the method is accessible from anywhere the class is
        {
            Program program = new();

            while (true)
            {
                break;
            }
        }

        public bool IsCommand(string _input)
        {
            foreach (Command command in commands)
            {
                if (command.IsThisCommand(_input) == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}