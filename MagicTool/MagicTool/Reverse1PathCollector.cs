using System.IO;
using System.Linq;

namespace MagicTool
{
    public class Reverse1PathCollector : IPathCollector
    {
        public string Collect(string path)
        {
            return string.Join(Path.DirectorySeparatorChar.ToString(), path.Split(Path.DirectorySeparatorChar).Reverse());
        }

        public bool IsValid(string path)
        {
            return true;
        }
    }
}
