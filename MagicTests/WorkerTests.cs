using System.IO;
using System.Threading.Tasks;
using MagicTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicTests
{
    [TestClass()]
    public class WorkerTests
    {
        [TestMethod()]
        public void WriteAllFileExistsTest()
        {
            var filepath = @"res.txt";
            var worker = new Worker(Path.GetTempPath(), filepath, new AllPathCollector());
            Task.WaitAll(worker.Do());
            worker.Write();

            Assert.AreEqual(true, File.Exists(filepath));
        }

        [TestMethod()]
        public void WriteCppFileExistsTest()
        {
            var filepath = @"res.txt";
            var worker = new Worker(Path.GetTempPath(), filepath, new CppPathCollector());
            Task.WaitAll(worker.Do());
            worker.Write();
            Assert.AreEqual(true, File.Exists(filepath));
        }

        [TestMethod()]
        public void WriteReverse1FileExistsTest()
        {
            var filepath = @"res.txt";
            var worker = new Worker(Path.GetTempPath(), filepath, new Reverse1PathCollector());
            Task.WaitAll(worker.Do());
            worker.Write();
            Assert.AreEqual(true, File.Exists(filepath));
        }

        [TestMethod()]
        public void WriteReverse2FileExistsTest()
        {
            var filepath = @"res.txt";
            var worker = new Worker(Path.GetTempPath(), @"res.txt", new Reverse2PathCollector());
            Task.WaitAll(worker.Do());
            worker.Write();
            Assert.AreEqual(true, File.Exists(filepath));
        }

        [TestMethod()]
        public void DoTest()
        {
            var worker = new Worker(Path.GetTempPath(), @"res.txt", new Reverse2PathCollector());
            Assert.AreEqual(typeof(Task), worker.Do().GetType().BaseType);
        }
    }
}