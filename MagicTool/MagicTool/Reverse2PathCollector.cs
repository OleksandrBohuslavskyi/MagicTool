using System.Linq;
using System.Text;

namespace MagicTool
{
    public class Reverse2PathCollector : IPathCollector
    {
        public string Collect(string path)
        {
            return  string.Concat(path.Reverse());
        }

        public bool IsValid(string path)
        {
            return true;
        }
    }
}
