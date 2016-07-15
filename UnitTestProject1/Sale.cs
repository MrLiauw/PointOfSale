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
            if(price == null)
                display.DisplayNoSaleInProgressMessage();
            else
            {
                display.Text = "Total: $6.50";
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