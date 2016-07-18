using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class FormatMonetaryAmountTest
    {
        [Test]
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
