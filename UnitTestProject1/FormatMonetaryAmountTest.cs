using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class FormatMonetaryAmountTest
    {
        [TestCase("$7.89", 789, TestName = "Monetary amount of 789 formatted to $7.89")]
        [TestCase("$5.20", 520, TestName = "Monetary amount of 520 formatted to $5.20")]
        public void Simplest(string expected, int priceWithCents)
        {
            Assert.AreEqual(expected, format(priceWithCents));
        }

        private static string format(int priceInCents)
        {
            decimal price = (decimal)priceInCents/100;
            return string.Format("${0}", price.ToString("#.00"));
        }
    }
}
