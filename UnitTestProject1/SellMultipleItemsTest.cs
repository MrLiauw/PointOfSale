using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class SellMultipleItemsTest
    {
        [TestMethod]
        public void ZeroItems()
        {
            Display display = new Display();
            Sale sale = new Sale(null, display);
            sale.onTotal();
            Assert.AreEqual("No sale in progress. Try scanning a product",
                display.getText());
        }

        [TestMethod]
        public void OneItemFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, string>() { { "12345", "$6.50" } },
                new Dictionary<string, int>() { { "12345", 650 } });
            Sale sale = new Sale(catalog, display);

            sale.onBarCode("12345");
            sale.onTotal();

            Assert.AreEqual("Total: $6.50", display.getText());
        }

        [TestMethod]
        public void OneItemNotFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, string>() { { "12345", "$6.50" } },
                new Dictionary<string, int>() { { "12345", 650 } });
            Sale sale = new Sale(catalog, display);

            sale.onBarCode("99999");
            sale.onTotal();

            Assert.AreEqual("No sale in progress. Try scanning a product",
                display.getText());
        }

        [TestMethod]
        [Ignore]
        public void severalItemsAllFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, string>(){
                {"1","$8.50"},
                {"2", "$12.75"},
                {"3", "$3.30"}
            }, new Dictionary<string, int>(){
                {"1",850},
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