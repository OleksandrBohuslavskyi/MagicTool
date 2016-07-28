using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MagicTool
{
    public class Worker
    {
        private readonly IMagic _iMagic;
        private readonly string _path;
        private readonly string _resultFilePath;
        private readonly List<string> _pathList = new List<string>();

        public Worker(string path, string resultFilePath, IMagic iMagic)
        {
            _path = path;
            _resultFilePath = resultFilePath;
            _iMagic = iMagic;
        }

        public async Task Do()
        {
            await DoAsync();
        }

        private Task DoAsync()
        {
            return Task.Run(() =>
            {
                Inside(_path);
            }
           );
        }

        private void Inside(string folderPath)
        {
            try
            {
                foreach (var file in Directory.GetFiles(folderPath).Where(file => _iMagic.IsValid(file)))
                {
                    _pathList.Add(_iMagic.DoMagic(file));
                }
                foreach (var directory in Directory.GetDirectories(folderPath))
                {
                    Inside(directory);
                }
            }
            catch
            {
                // ignored
            }
        }

        public void Write()
        {
            using (TextWriter tw = new StreamWriter(_resultFilePath))
            {
                foreach (var s in _pathList)
                {
                    tw.WriteLine(s);
                }
            }
        }
    }
}
