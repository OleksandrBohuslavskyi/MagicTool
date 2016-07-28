using System.IO;
using MagicTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicTests
{
    [TestClass()]
    public class CppCollectorTests
    {
        [TestMethod()]
        public void CollectTest()
        {
            var tempFilePath = Path.GetTempFileName();
            Assert.AreEqual(tempFilePath + " /", new CppPathCollector().Collect(tempFilePath));
        }

        [TestMethod()]
        public void CollectTest_fixedValues()
        {
            Assert.AreEqual(" /", new CppPathCollector().Collect(""));
        }

        [TestMethod()]
        public void IsValidTrueTest()
        {
            var tempFilePath = Path.GetTempFileName() + ".cpp";
            Assert.AreEqual(true, new CppPathCollector().IsValid(tempFilePath));
        }

        [TestMethod()]
        public void IsValidFalseTest()
        {
            Assert.AreNotEqual(true, new CppPathCollector().IsValid(string.Empty));
        }
    }
}