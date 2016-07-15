using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Catalog catalog = new Catalog(new Dictionary<string, string>(){{"12345","$6.50"}});
            Sale sale = new Sale(catalog, display);

            sale.onBarCode("12345");
            sale.onTotal();

            Assert.AreEqual("Total: $6.50", display.getText());            
        }

        [TestMethod]
        public void OneItemNotFound()
        {
            Display display = new Display();
            Catalog catalog = new Catalog(new Dictionary<string, string>(){{"12345","$6.50"}});
            Sale sale = new Sale(catalog, display);

            sale.onBarCode("99999");
            sale.onTotal();

            Assert.AreEqual("No sale in progress. Try scanning a product", 
                display.getText());
        }
    }
}
