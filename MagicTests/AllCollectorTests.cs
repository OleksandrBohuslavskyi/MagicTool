using System.IO;
using MagicTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicTests
{
    [TestClass()]
    public class AllCollectorTests
    {
        [TestMethod()]
        public void CollectTest()
        {
            var tempFilePath = Path.GetTempFileName();
            Assert.AreEqual(tempFilePath, new AllPathCollector().Collect(tempFilePath));
        }

        [TestMethod()]
        public void CollectTest_fixedValues()
        {
            Assert.AreEqual("", new AllPathCollector().Collect(""));
        }

        [TestMethod()]
        public void IsValidTest()
        {
            Assert.AreEqual(true, new AllPathCollector().IsValid(string.Empty));
        }
    }
}