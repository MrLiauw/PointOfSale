using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestFixture]
    public class SellMultipleItemsTest
    {
        [Test]
        public void ZeroItems()
        {
            Display display = new Display();
            Sale sale = new Sale(null, display);
            sale.onTotal();
            Assert.AreEqual("No sale in progress. Try scanning a product",
                display.getText());
        }

        [Test]
        public void OneItemFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, int>() { { "12345", 650 } });
            Sale sale = new Sale(catalog, display);

            sale.onBarCode("12345");
            sale.onTotal();

            Assert.AreEqual("Total: $6.50", display.getText());
        }

        [Test]
        public void OneItemNotFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, int>() { { "12345", 650 } });
            Sale sale = new Sale(catalog, display);

            sale.onBarCode("99999");
            sale.onTotal();

            Assert.AreEqual("No sale in progress. Try scanning a product",
                display.getText());
        }

        [Test]
        public void severalItemsAllNotFound()
        {
            Display display = new Display();
            Sale sale = new Sale(catalogWithoutBarcodes("product you won't find",
                "another product you won't find",
                "a thord product you won't find"),
                display);

            sale.onBarCode("product you won't find");
            sale.onBarCode("another product you won't find");
            sale.onBarCode("a third product you won't find");
            sale.onTotal();

            Assert.AreEqual("No sale in progress. Try scanning a product",
                display.getText());
        }

        private Catalog catalogWithoutBarcodes(string barcode1 = "", string barcode2 = "", string barcode3 = "")
        {
            return emptyCatalog();
        }

        private Catalog emptyCatalog()
        {
            return new Catalog(new Dictionary<string, int>());
        }

        [Test]
        public void severalItemsAllFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, int>(){
                {"1", 850},
                {"2", 1275},
                {"3", 330}
            });
            Sale sale = new Sale(catalog, display);

            sale.onBarCode("1");
            sale.onBarCode("2");
            sale.onBarCode("3");
            sale.onTotal();

            Assert.AreEqual("Total: $24.55", display.getText());
        }
    }
}