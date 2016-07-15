using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    internal class Sale
    {
        private Display display;
        private Catalog catalog;
        private string price;

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

            price = catalog.FindPrice(barcode);
            if (price == null)
                display.DisplayNotFoundMessage(barcode);
            else
            {
                display.DisplayPrice(price);
            }
        }

        internal void onTotal()
        {
            bool saleInProgress = (price != null);
            if (saleInProgress)
            {
                display.DisplayPurchaseTotal(price);
            }
            else
                display.DisplayNoSaleInProgressMessage();
        }
    }

    internal class Catalog
    {
        private Dictionary<string, string> _pricesByBarcode;
        private readonly Dictionary<string, int> _pricesInCentsByBarCode;

        [Obsolete]
        public Catalog(Dictionary<string, string> pricesByBarcode)
        {
            _pricesByBarcode = pricesByBarcode;
        }

        public Catalog(Dictionary<string, string> pricesByBarcode, Dictionary<string, int> pricesInCentsByBarCode)
        {
            _pricesByBarcode = pricesByBarcode;
            _pricesInCentsByBarCode = pricesInCentsByBarCode;
        }

        public string FindPrice(string barcode)
        {
            string storedPrice = null;
            _pricesByBarcode.TryGetValue(barcode, out storedPrice);
            return storedPrice;
        }
    }
}