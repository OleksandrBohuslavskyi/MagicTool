using System;

namespace MagicTool
{
    public class MagicFactory
    {
        private readonly string _command;

        public MagicFactory(string command)
        {
            _command = command;
        }

        public IMagic MakeMagicChoise()
        {
            switch (_command)
            {
                case "all":
                    return new AllMagic();
                case "cpp":
                    return new CppMagic();
                case "reversed1":
                    return new Reverse1Magic();
                case "reversed2":
                    return new Reverse2Magic();
                default:
                    throw new ArgumentException("Argument is null or whitespace", nameof(_command));
            }
        }
    }
}
