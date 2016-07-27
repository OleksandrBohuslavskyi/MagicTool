using System.IO;

namespace MagicTool
{
    public class CppMagic : IMagic
    {
        public string DoMagic(string path)
        {
            return path + @" /";
        }

        public bool IsValid(string path)
        {
            return Path.GetExtension(path) == ".cpp";
        }
    }
}
