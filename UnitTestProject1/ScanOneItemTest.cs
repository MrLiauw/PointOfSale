using System.Collections.Generic;
using NUnit.Framework;
using UnitTestProject1;

namespace test
{

    [TestFixture]
    public class ScanOneItemTest
    {
        private Display display;
        private Sale sale;

        [SetUp]
        public void Initialize()
        {
            display = new Display();
            sale = new Sale(new Catalog(new Dictionary<string, int>()
            {
                {"12345", 795},
                {"23456", 1250}
            }), display);
        }

        [Test]
        public void productFound()
        {
            sale.onBarCode("12345");
            Assert.AreEqual("$7.95", display.getText());
        }

        [Test]
        public void anotherProductFound()
        {
            sale.onBarCode("23456");
            Assert.AreEqual("$12.50", display.getText());
        }

        [Test]
        public void productNotFound()
        {
            sale.onBarCode("99999");
            Assert.AreEqual("Product not found for 99999", display.getText());
        }

        [Test]
        public void emptyBarCode()
        {
            Sale sale = new Sale(new Catalog((Dictionary<string, int>) null), display);

            sale.onBarCode("");
            Assert.AreEqual("Scanning error : empty barcode", display.getText());
        }
    }
}