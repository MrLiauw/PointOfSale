using System.Collections.Generic;

namespace UnitTestProject1
{
    internal class Sale
    {
        private Display display;
        private Catalog catalog;

        public Sale(Catalog catalog, Display display)
        {
            this.catalog = catalog;
            this.display = display;
        }

        internal void onBarCode(string barcode)
        {
            if (barcode == "")
            {
                display.DisplayEmptyBarcodeMessage();
                return;
            }

            string priceAsText = catalog.FindPrice(barcode);
            if (priceAsText == null)
                display.DisplayNotFoundMessage(barcode);
            else
            {
                display.DisplayPrice(priceAsText);
            }
        }
    }

    internal class Catalog
    {
        private Dictionary<string, string> _pricesByBarcode;

        public Catalog(Dictionary<string, string> pricesByBarcode)
        {
            _pricesByBarcode = pricesByBarcode;
        }

        public string FindPrice(string barcode)
        {
            string storedPrice = null;
            _pricesByBarcode.TryGetValue(barcode, out storedPrice);
            return storedPrice;
        }
    }
}