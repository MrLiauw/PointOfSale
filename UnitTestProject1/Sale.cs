using System.Collections.Generic;

namespace UnitTestProject1
{
    internal class Sale
    {
        private Display display;
        private Catalog catalog;
        private string scannedPrice;

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

            scannedPrice = catalog.FindPrice(barcode);
            if (scannedPrice == null)
                display.DisplayNotFoundMessage(barcode);
            else
            {
                display.DisplayPrice(scannedPrice);
            }
        }

        internal void onTotal()
        {
            bool saleInProgress = (scannedPrice != null);
            if (saleInProgress)
            {
                display.DisplayPurchaseTotal(scannedPrice);
            }
            else
                display.DisplayNoSaleInProgressMessage();
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