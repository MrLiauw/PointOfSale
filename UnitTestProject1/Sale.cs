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
                display.Text = "Scanning error : empty barcode";
            }
            else
            {
                if (pricesByBarcode.ContainsKey(barcode))
                    display.Text = pricesByBarcode[barcode];
                else
                    display.Text = "Product not found for " + barcode;
            }
        }
    }
}