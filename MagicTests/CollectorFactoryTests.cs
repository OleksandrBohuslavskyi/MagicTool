using System;
using MagicTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicTests
{
    [TestClass()]
    public class CollectorFactoryTests
    {
        [TestMethod()]
        public void AllTypeTest()
        {
            var factory = new CollectorFactory("all").MakeAChoise();
            Assert.AreEqual(new AllPathCollector().GetType(), factory.GetType());
        }

        [TestMethod()]
        public void CppTypeTest()
        {
            var factory = new CollectorFactory("cpp").MakeAChoise();
            Assert.AreEqual(new CppPathCollector().GetType(), factory.GetType());
        }

        [TestMethod()]
        public void Reverse1TypeTest()
        {
            var factory = new CollectorFactory("reversed1").MakeAChoise();
            Assert.AreEqual(new Reverse1PathCollector().GetType(), factory.GetType());
        }

        [TestMethod()]
        public void Reverse2TypeTest()
        {
            var factory = new CollectorFactory("reversed2").MakeAChoise();
            Assert.AreEqual(new Reverse2PathCollector().GetType(), factory.GetType());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidCommandTest()
        {
            new CollectorFactory("xxx").MakeAChoise();
        }
    }
}