using System.Collections.Generic;

namespace UnitTestProject1
{
    internal class Sale
    {
        private Display display;
        private Dictionary<string, string> pricesByBarcode;

        public Sale(Display display, Dictionary<string, string> pricesByBarcode)
        {
            this.display = display;
            this.pricesByBarcode = pricesByBarcode;
        }

        internal void onBarCode(string barcode)
        {
            if (barcode == "")
            {
                DisplayEmptyBarcodeMessage();
                return;
            }
            if (pricesByBarcode.ContainsKey(barcode))
                FindPriceThenDisplay(barcode);
            else
                DisplayNotFoundMessage(barcode);
        }

        private void DisplayNotFoundMessage(string barcode)
        {
            display.Text = "Product not found for " + barcode;
        }

        private void FindPriceThenDisplay(string barcode)
        {
            string priceAsText = FindPrice(barcode);
            DisplayPrice(priceAsText);
        }

        private void DisplayPrice(string priceAsText)
        {
            display.Text = priceAsText;
        }

        private string FindPrice(string barcode)
        {
            return pricesByBarcode[barcode];
        }

        private void DisplayEmptyBarcodeMessage()
        {
            display.Text = "Scanning error : empty barcode";
        }
    }
}