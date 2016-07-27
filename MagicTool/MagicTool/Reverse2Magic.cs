using System.Linq;

namespace MagicTool
{
    public class Reverse2Magic : IMagic
    {
        public string DoMagic(string path)
        {
            return path.Reverse().Aggregate(string.Empty, (current, str) => current +  str);
        }

        public bool IsValid(string path)
        {
            return true;
        }
    }
}
