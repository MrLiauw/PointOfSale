using System;

namespace UnitTestProject1
{
    class Display
    {
        private string Text;

        internal object getText()
        {
            return Text;
        }

        public void DisplayNotFoundMessage(string barcode)
        {
            Text = "Product not found for " + barcode;
        }

        public void DisplayText(string priceAsText)
        {
            Text = priceAsText;
        }

        public void DisplayEmptyBarcodeMessage()
        {
            Text = "Scanning error : empty barcode";
        }

        public void DisplayNoSaleInProgressMessage()
        {
            Text = "No sale in progress. Try scanning a product";
        }

        public void DisplayPurchaseTotal(string price)
        {
            Text = "Total: " + price;
        }

        public static string Format(int priceInCents)
        {
            decimal price = (decimal)priceInCents/100;
            return String.Format("${0}", price.ToString("#,##0.00"));
        }
    }
}
