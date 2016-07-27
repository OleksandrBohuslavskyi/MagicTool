namespace MagicTool
{
    public interface IMagic
    {
        bool IsValid(string path);
        string DoMagic(string path);
    }
}
