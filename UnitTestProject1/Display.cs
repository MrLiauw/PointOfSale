using System;

namespace UnitTestProject1
{
    class Display
    {
        private string Text;

        internal string getText()
        {
            return Text;
        }

        public void DisplayNotFoundMessage(string barcode)
        {
            Text = "Product not found for " + barcode;
        }

        public void DisplayEmptyBarcodeMessage()
        {
            Text = "Scanning error : empty barcode";
        }

        public void DisplayNoSaleInProgressMessage()
        {
            Text = "No sale in progress. Try scanning a product";
        }

        public void DisplayPurchaseTotal(int purchaseTotal)
        {
            Text = "Total: " + Format(purchaseTotal);
        }

        public static string Format(int priceInCents)
        {
            decimal price = (decimal)priceInCents/100;
            return String.Format("${0}", price.ToString("#,##0.00"));
        }

        public void DisplayPrice(int priceInCents)
        {
            Text = Format(priceInCents);
        }
    }
}
