using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MagicTool
{
    public class Worker
    {
        private readonly IPathCollector _iPathCollector;
        private readonly string _path;
        private readonly string _resultFilePath;
        private readonly List<string> _pathList;

        public Worker(string path, string resultFilePath, IPathCollector iPathCollector)
        {
            _path = path;
            _resultFilePath = resultFilePath;
            _iPathCollector = iPathCollector;
            _pathList = new List<string>();
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
            });
        }

        private void Inside(string folderPath)
        {
            try
            {
                foreach (var file in Directory.GetFiles(folderPath).Where(file => _iPathCollector.IsValid(file)))
                {
                    _pathList.Add(_iPathCollector.Collect(file));
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
            using (TextWriter textWriter = new StreamWriter(_resultFilePath))
            {
                foreach (var path in _pathList)
                {
                    textWriter.WriteLine(path);
                }
            }
        }
    }
}
