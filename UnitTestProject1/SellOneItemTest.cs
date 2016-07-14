using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1;

namespace test
{

    [TestClass]
    public class SellOneItemTest
    {
        private Display display;
        private Sale sale;

        [TestInitialize]
        public void Initialize()
        {
            display = new Display();
            sale = new Sale(new Catalog(new Dictionary<string, string>()
            {
                {"12345", "$7.95"},
                {"23456", "$12.50"}
            }), display);
        }

        [TestMethod]
        public void productFound()
        {
            sale.onBarCode("12345");
            Assert.AreEqual("$7.95", display.getText());
        }

        [TestMethod]
        public void anotherProductFound()
        {
            sale.onBarCode("23456");
            Assert.AreEqual("$12.50", display.getText());
        }

        [TestMethod]
        public void productNotFound()
        {
            sale.onBarCode("99999");
            Assert.AreEqual("Product not found for 99999", display.getText());
        }

        [TestMethod]
        public void emptyBarCode()
        {
            Sale sale = new Sale(new Catalog(null), display);

            sale.onBarCode("");
            Assert.AreEqual("Scanning error : empty barcode", display.getText());
        }
    }
}