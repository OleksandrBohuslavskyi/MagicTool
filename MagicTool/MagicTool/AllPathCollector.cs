namespace MagicTool
{
    public class AllPathCollector : IPathCollector
    {
        public string Collect(string path)
        {
            return path;
        }

        public bool IsValid(string path)
        {
            return true;
        }
    }
}
