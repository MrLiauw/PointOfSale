using System.Collections.Generic;

namespace UnitTestProject1
{
    internal class Sale
    {
        private Display display;
        private Dictionary<string, string> pricesByBarcode;

        public Sale(Display display)
        {
            this.display = display;
            pricesByBarcode = new Dictionary<string, string>()
                {
                    {"12345", "$7.95"},
                    {"23456", "$12.50"}
                };
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