using System.IO;
using System.Linq;

namespace MagicTool
{
    public class Reverse1Magic : IMagic
    {
        public string DoMagic(string path)
        {
            return path.Split(Path.DirectorySeparatorChar).Reverse().Aggregate(string.Empty, (current, str) => current + (Path.DirectorySeparatorChar + str));
        }

        public bool IsValid(string path)
        {
            return true;
        }
    }
}
