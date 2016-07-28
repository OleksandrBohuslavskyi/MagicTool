using System.IO;

namespace MagicTool
{
    public class CppPathCollector : IPathCollector
    {
        public string Collect(string path)
        {
            return path + @" /";
        }

        public bool IsValid(string path)
        {
            return Path.GetExtension(path) == ".cpp";
        }
    }
}
