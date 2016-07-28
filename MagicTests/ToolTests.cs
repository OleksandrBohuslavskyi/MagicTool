﻿using MagicTool;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ToolTests
{
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
            var tempFilePath = Path.GetTempFileName();
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
           Assert.AreEqual("check/test", new Reverse1Magic().DoMagic("test/check"));
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
            Assert.AreEqual("check/test", new Reverse1Magic().DoMagic("test/check"));
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
            Worker worker = new Worker(Path.GetTempPath(), new AllMagic());
            Assert.IsNotNull(worker);
        }

        [TestMethod()]
        public void WorkerCppNotNullTest()
        {
            Worker worker = new Worker(Path.GetTempPath(), new CppMagic());
            Assert.IsNotNull(worker);
        }

        [TestMethod()]
        public void WorkerReverse1NotNullTest()
        {
            Worker worker = new Worker(Path.GetTempPath(), new Reverse1Magic());
            Assert.IsNotNull(worker);
        }

        [TestMethod()]
        public void WorkerReverse2NotNullTest()
        {
            Worker worker = new Worker(Path.GetTempPath(), new Reverse2Magic());
            Assert.IsNotNull(worker);
        }

        [TestMethod()]
        public void WriteAllFileExistsTest()
        {
            Worker worker = new Worker(Path.GetTempPath(), new AllMagic());
            worker.Do();

            Assert.AreEqual(true, File.Exists(worker.Write()));
        }

        [TestMethod()]
        public void WriteCppFileExistsTest()
        {
            Worker worker = new Worker(Path.GetTempPath(), new CppMagic());
            worker.Do();

            Assert.AreEqual(true, File.Exists(worker.Write()));
        }

        [TestMethod()]
        public void WriteReverse1FileExistsTest()
        {
            Worker worker = new Worker(Path.GetTempPath(), new Reverse1Magic());
            worker.Do();

            Assert.AreEqual(true, File.Exists(worker.Write()));
        }

        [TestMethod()]
        public void WriteReverse2FileExistsTest()
        {
            Worker worker = new Worker(Path.GetTempPath(), new Reverse2Magic());
            worker.Do();

            Assert.AreEqual(true, File.Exists(worker.Write()));
        }

        [TestMethod()]
        public void DoTest()
        {
            Assert.Fail();
        }
    }
}
