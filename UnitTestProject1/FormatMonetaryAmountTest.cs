using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class FormatMonetaryAmountTest
    {
        [TestCase("$7.89", 789, TestName = "Monetary amount of 789 formatted to $7.89")]
        [TestCase("$5.20", 520, TestName = "Monetary amount of 520 formatted to $5.20")]
        [TestCase("$4.00", 400, TestName = "Monetary amount of 400 formatted to $4.00")]
        [TestCase("$0.00", 0, TestName = "Monetary amount of 0 formatted to $0.00")]
        [TestCase("$0.02", 2, TestName = "Monetary amount of 2 formatted to $0.02")]
        [TestCase("$0.37", 37, TestName = "Monetary amount of 37 formatted to $0.37")]
        public void Simplest(string expected, int priceWithCents)
        {
            Assert.AreEqual(expected, format(priceWithCents));
        }

        private static string format(int priceInCents)
        {
            decimal price = (decimal)priceInCents/100;
            return string.Format("${0}", price.ToString("0.00"));
        }
    }
}
