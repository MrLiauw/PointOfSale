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
    }
}
