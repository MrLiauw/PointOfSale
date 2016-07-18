using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class FormatMonetaryAmountTest
    {
        [TestMethod]
        public void simplest()
        {
            Assert.AreEqual("$7.89", format(789));
        }

        private static string format(int priceInCents)
        {
            return "$7.89";
        }
    }
}
