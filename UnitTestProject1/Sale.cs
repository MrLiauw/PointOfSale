using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    internal class Sale
    {
        private Display display;
        private Catalog catalog;
        private IList<int> pendingPurchaseItemPrices = new List<int>(); 

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
                pendingPurchaseItemPrices.Add(priceInCents);
                display.DisplayPrice(pendingPurchaseItemPrices[0]);
            }
        }

        internal void onTotal()
        {
            if (pendingPurchaseItemPrices.Count == 0)
                display.DisplayNoSaleInProgressMessage();
            else
                display.DisplayPurchaseTotal(PendingPurchaseTotal());
        }

        private int PendingPurchaseTotal()
        {
            return ComputePendingPurchaseTotal(pendingPurchaseItemPrices);
        }

        public static int ComputePendingPurchaseTotal(IList<int> purchaseItemPrices)
        {
            return purchaseItemPrices.Sum(x=>x);
        }
    }

    internal class Catalog
    {
        private readonly Dictionary<string, int> _pricesInCentsByBarCode;

        public Catalog(Dictionary<string, int> pricesInCentsByBarCode)
        {
            _pricesInCentsByBarCode = pricesInCentsByBarCode;
        }

        public int FindPrice(string barcode)
        {
            if (!_pricesInCentsByBarCode.ContainsKey(barcode)) return -1;
            return _pricesInCentsByBarCode[barcode];
        }
    }
}