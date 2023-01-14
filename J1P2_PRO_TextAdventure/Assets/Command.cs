namespace J1P2_PRO_TextAdventure.Assets
{
    internal abstract class Command
    {
        private readonly string keyword;
        private readonly string[]? arguments;
        private string? argument;

        protected string? Argument { get => argument; }


        public Command(string _keyword)
        {
            keyword = _keyword;
            arguments = null;
            argument = null;
        }

        public Command(string _keyword, params string[] _arguments)
        {
            keyword = _keyword;
            arguments = _arguments;
            argument = null;
        }

        public bool TryRunCommand(string _value)
        {
            if (_value.StartsWith(keyword) && arguments == null)
            {
                OnRun();
                return true;
            }
            else if (_value.StartsWith(keyword))
            {
                argument = GetArgument(keyword);

                if (argument != null)
                {
                    OnRun();
                    return true;
                }
            }

            return false;
        }

        private string? GetArgument(string _value)
        {
            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments), "you need to assign this command arguments during construction to get an argument");
            }

            foreach (string argument in arguments)
            {
                if (_value.EndsWith(argument))
                {
                    return argument;
                }
            }

            return null;
        }

        protected abstract void OnRun();
    }
}
