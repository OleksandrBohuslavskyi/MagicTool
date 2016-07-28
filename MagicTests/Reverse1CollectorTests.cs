using MagicTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicTests
{
    [TestClass()]
    public class Reverse1CollectorTests
    {
        [TestMethod()]
        public void CollectTest()
        {
            Assert.AreEqual(@"check\test", new Reverse1PathCollector().Collect(@"test\check"));
        }

        [TestMethod()]
        public void IsValidTest()
        {
            Assert.AreEqual(true, new Reverse1PathCollector().IsValid(string.Empty));
        }
    }
}