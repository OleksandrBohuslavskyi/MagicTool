using MagicTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicTests
{
    [TestClass()]
    public class Reverse2CollectorTests
    {
        [TestMethod()]
        public void CollectTest()
        {
            Assert.AreEqual(@"kcehc\tset\", new Reverse2PathCollector().Collect(@"\test\check"));
        }

        [TestMethod()]
        public void IsValidTest()
        {
            Assert.AreEqual(true, new Reverse2PathCollector().IsValid(string.Empty));
        }
    }
}