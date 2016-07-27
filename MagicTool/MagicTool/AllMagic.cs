namespace MagicTool
{
    public class AllMagic : IMagic
    {
        public string DoMagic(string path)
        {
            return path;
        }

        public bool IsValid(string path)
        {
            return true;
        }
    }
}
