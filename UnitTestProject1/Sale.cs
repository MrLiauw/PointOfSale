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
                DisplayPrice(barcode);
            else
                DisplayNotFoundMessage(barcode);
        }

        private string DisplayNotFoundMessage(string barcode)
        {
            return display.Text = "Product not found for " + barcode;
        }

        private void DisplayPrice(string barcode)
        {
            display.Text = pricesByBarcode[barcode];
        }

        private void DisplayEmptyBarcodeMessage()
        {
            display.Text = "Scanning error : empty barcode";
        }
    }
}