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

            var priceInCents = catalog.FindPrice(barcode);
            if (priceInCents == -1)
                display.DisplayNotFoundMessage(barcode);
            else
            {
                price = Display.Format(priceInCents);
                display.DisplayText(Display.Format(priceInCents));
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

        public int FindPrice(string barcode)
        {
            if (!_pricesInCentsByBarCode.ContainsKey(barcode)) return -1;
            return _pricesInCentsByBarCode[barcode];
        }
    }
}