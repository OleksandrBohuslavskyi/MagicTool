using MagicTool;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace ToolTests
{
    [TestClass()]
    public class MagicFactoryTests
    {
        [TestMethod()]
        public void MagicFactoryAllIsNotNullMagicFactoryTest()
        {
            var factory = new MagicFactory("all");
            Assert.IsNotNull(factory);
        }

        [TestMethod()]
        public void MagicFactoryCppIsNotNullMagicFactoryTest()
        {
            var factory = new MagicFactory("cpp");
            Assert.IsNotNull(factory);
        }

        [TestMethod()]
        public void MagicFactoryReverse1IsNotNullMagicFactoryTest()
        {
            var factory = new MagicFactory("reversed1");
            Assert.IsNotNull(factory);
        }

        [TestMethod()]
        public void MagicFactoryReverse2IsNotNullMagicFactoryTest()
        {
            var factory = new MagicFactory("reversed2");
            Assert.IsNotNull(factory);
        }

        [TestMethod()]
        public void MagicFactoryAllTypeMagicFactoryTest()
        {
            var factory = new MagicFactory("all").MakeMagicChoise();
            Assert.AreEqual(new AllMagic().GetType(), factory.GetType());
        }

        [TestMethod()]
        public void MagicFactoryCppTypeMagicFactoryTest()
        {
            var factory = new MagicFactory("cpp").MakeMagicChoise();
            Assert.AreEqual(new CppMagic().GetType(), factory.GetType());
        }

        [TestMethod()]
        public void MagicFactoryReverse1TypeMagicFactoryTest()
        {
            var factory = new MagicFactory("reversed1").MakeMagicChoise();
            Assert.AreEqual(new Reverse1Magic().GetType(), factory.GetType());
        }

        [TestMethod()]
        public void MagicFactoryReverse2TypeMagicFactoryTest()
        {
            var factory = new MagicFactory("reversed2").MakeMagicChoise();
            Assert.AreEqual(new Reverse2Magic().GetType(), factory.GetType());
        }
    }

    [TestClass()]
    public class AllMagicTests
    {
        [TestMethod()]
        public void AllMagicDoMagicTest()
        {
            var tempFilePath = Path.GetTempFileName();
            Assert.AreEqual(tempFilePath, new AllMagic().DoMagic(tempFilePath));
        }

        [TestMethod()]
        public void AllMagicDoMagicTest_fixedValues()
        {
            Assert.AreEqual("", new AllMagic().DoMagic(""));
        }

        [TestMethod()]
        public void AllMagicIsValidTest()
        {
            Assert.AreEqual(true, new AllMagic().IsValid(string.Empty));
        }
    }

    [TestClass()]
    public class CppMagicTests
    {
        [TestMethod()]
        public void CppMagicDoMagicTest()
        {
            var tempFilePath = Path.GetTempFileName();
            Assert.AreEqual(tempFilePath + " /", new CppMagic().DoMagic(tempFilePath));
        }

        [TestMethod()]
        public void CppMagicDoMagicTest_fixedValues()
        {
            Assert.AreEqual(" /", new CppMagic().DoMagic(""));
        }

        [TestMethod()]
        public void CppMagicIsValidTrueTest()
        {
            var tempFilePath = Path.GetTempFileName() + ".cpp";
            Assert.AreEqual(true, new CppMagic().IsValid(tempFilePath));
        }

        [TestMethod()]
        public void CppMagicIsValidFalseTest()
        {
            Assert.AreNotEqual(true, new CppMagic().IsValid(string.Empty));
        }
    }

    [TestClass()]
    public class Reverse1MagicTests
    {
        [TestMethod()]
        public void Reverse1MagicDoMagicTest()
        {
            var tempFilePath = Path.GetTempFileName();
            var expectedPath = tempFilePath.Split(Path.DirectorySeparatorChar)
                .Reverse()
                .Aggregate(string.Empty, (current, str) => current + (Path.DirectorySeparatorChar + str));
            Assert.AreEqual(expectedPath, new Reverse1Magic().DoMagic(tempFilePath));
        }

        [TestMethod()]
        public void Reverse1MagicDoMagicTest_fixedValues()
        {
            Assert.AreEqual(@"\check\test", new Reverse1Magic().DoMagic(@"test\check"));
        }

        [TestMethod()]
        public void Reverse1MagicIsValidTest()
        {
            Assert.AreEqual(true, new Reverse1Magic().IsValid(string.Empty));
        }
    }

    [TestClass()]
    public class Reverse2MagicTests
    {
        [TestMethod()]
        public void Reverse2MagicDoMagicTest()
        {
            var tempFilePath = Path.GetTempFileName();
            var expectedPath = tempFilePath.Reverse().Aggregate(string.Empty, (current, str) => current + str);
            Assert.AreEqual(expectedPath, new Reverse2Magic().DoMagic(tempFilePath));
        }

        [TestMethod()]
        public void Reverse2MagicDoMagicTest_fixedValues()
        {
            Assert.AreEqual(@"kcehc\tset\", new Reverse2Magic().DoMagic(@"\test\check"));
        }

        [TestMethod()]
        public void Reverse2MagicIsValidTest()
        {
            Assert.AreEqual(true, new Reverse2Magic().IsValid(string.Empty));
        }
    }
}

namespace ToolTests
{
    [TestClass()]
    public class WorkerTests
    {
        [TestMethod()]
        public void WorkerAllNotNullTest()
        {
            var worker = new Worker(Path.GetTempPath(), "result.txt", new AllMagic());
            Assert.IsNotNull(worker);
        }

        [TestMethod()]
        public void WorkerCppNotNullTest()
        {
            var worker = new Worker(Path.GetTempPath(), "result.txt", new CppMagic());
            Assert.IsNotNull(worker);
        }

        [TestMethod()]
        public void WorkerReverse1NotNullTest()
        {
            var worker = new Worker(Path.GetTempPath(), "result.txt", new Reverse1Magic());
            Assert.IsNotNull(worker);
        }

        [TestMethod()]
        public void WorkerReverse2NotNullTest()
        {
            var worker = new Worker(Path.GetTempPath(), "result.txt", new Reverse2Magic());
            Assert.IsNotNull(worker);
        }

        [TestMethod()]
        public void WriteAllFileExistsTest()
        {
            var filepath = @"res.txt";
            var worker = new Worker(Path.GetTempPath(), filepath, new AllMagic());
            Task.WaitAll(worker.Do());
            worker.Write();

            Assert.AreEqual(true, File.Exists(filepath));
        }

        [TestMethod()]
        public void WriteCppFileExistsTest()
        {
            var filepath = @"res.txt";
            var worker = new Worker(Path.GetTempPath(), filepath, new CppMagic());
            Task.WaitAll(worker.Do());
            worker.Write();
            Assert.AreEqual(true, File.Exists(filepath));
        }

        [TestMethod()]
        public void WriteReverse1FileExistsTest()
        {
            var filepath = @"res.txt";
            var worker = new Worker(Path.GetTempPath(), filepath, new Reverse1Magic());
            Task.WaitAll(worker.Do());
            worker.Write();
            Assert.AreEqual(true, File.Exists(filepath));
        }

        [TestMethod()]
        public void WriteReverse2FileExistsTest()
        {
            var filepath = @"res.txt";
            var worker = new Worker(Path.GetTempPath(), @"res.txt", new Reverse2Magic());
            Task.WaitAll(worker.Do());
            worker.Write();
            Assert.AreEqual(true, File.Exists(filepath));
        }

        [TestMethod()]
        public void DoTest()
        {
            var worker = new Worker(Path.GetTempPath(), @"res.txt", new Reverse2Magic());
            Assert.AreEqual(typeof(Task), worker.Do().GetType().BaseType);
        }
    }
}
