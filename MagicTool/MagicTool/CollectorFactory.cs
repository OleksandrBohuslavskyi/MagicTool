using System;

namespace MagicTool
{
    public class CollectorFactory
    {
        private readonly string _command;

        public CollectorFactory(string command)
        {
            _command = command;
        }

        public IPathCollector MakeAChoise()
        {
            switch (_command)
            {
                case "all":
                    return new AllPathCollector();
                case "cpp":
                    return new CppPathCollector();
                case "reversed1":
                    return new Reverse1PathCollector();
                case "reversed2":
                    return new Reverse2PathCollector();
                default:
                    throw new ArgumentException("Argument invalid", nameof(_command));
            }
        }
    }
}
