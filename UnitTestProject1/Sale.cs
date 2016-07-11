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
                display.DisplayEmptyBarcodeMessage();
                return;
            }

            string priceAsText = FindPrice(barcode);
            if (priceAsText == null)
                display.DisplayNotFoundMessage(barcode);
            else
            {
                display.DisplayPrice(priceAsText);
            }
        }

        private string FindPrice(string barcode)
        {
            string storedPrice = null;
            pricesByBarcode.TryGetValue(barcode, out storedPrice);
            return storedPrice;
        }
    }
}