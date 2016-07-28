using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject1
{
    [TestClass]
    public class ComputePurchaseTotalTest
    {
        [TestMethod]
        public void zeroItems()
        {
            Assert.AreEqual(0, Sale.ComputePendingPurchaseTotal(new List<int>(Enumerable.Empty<int>())));
        }

        [Test]
        public void oneItem()
        {
            Assert.AreEqual(795, Sale.ComputePendingPurchaseTotal(new List<int>(){795}));
        }

        [Test]
        public void multipleItems()
        {
            Assert.AreEqual(2455, Sale.ComputePendingPurchaseTotal(new List<int>() { 850, 1275, 330 }));
        }
    }
}
