namespace MagicTool
{
    public interface IPathCollector
    {
        bool IsValid(string path);
        string Collect(string path);
    }
}
