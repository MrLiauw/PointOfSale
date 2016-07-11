using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1;

namespace test
{
    [TestClass]
    public class SellOneItemTest
    {
        [TestMethod]
        public void productFound()
        {
            Display display = new Display();
            Sale sale = new Sale(display);

            sale.onBarCode("12345");
            Assert.AreEqual("$7.95", display.getText());
        }

        [TestMethod]
        public void anotherProductFound()
        {
            Display display = new Display();
            Sale sale = new Sale(display);

            sale.onBarCode("23456");
            Assert.AreEqual("$12.50", display.getText());
        }

        [TestMethod]
        public void productNotFound()
        {
            Display display = new Display();
            Sale sale = new Sale(display);

            sale.onBarCode("99999");
            Assert.AreEqual("Product not found for 99999", display.getText());
        }

        [TestMethod]
        public void emptyBarCode()
        {
            Display display = new Display();
            Sale sale = new Sale(display);

            sale.onBarCode("");
            Assert.AreEqual("Scanning error : empty barcode", display.getText());
        }
    }
}