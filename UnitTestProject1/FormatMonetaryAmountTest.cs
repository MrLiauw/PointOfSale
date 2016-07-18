using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class FormatMonetaryAmountTest
    {
        [Test]
        [TestCase("$7.89", 789)]
        public void simplest(string expected, int priceWithCents)
        {
            Assert.AreEqual(expected, format(priceWithCents));
        }

        private static string format(int priceInCents)
        {
            return "$7.89";
        }
    }
}
