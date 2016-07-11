using System.Collections.Generic;
using System.Net.Mail;

namespace UnitTestProject1
{
    class Sale
    {
        private Display display;

        public Sale(Display display)
        {
            this.display = display;
        }

        internal void onBarCode(string barcode)
        {
            if (barcode == "")
            {
                display.Text = "Scanning error : empty barcode";
            }
            else
            {
                Dictionary<string, string> lookupTable = new Dictionary<string, string>()
                {
                    {"12345", "$7.95"},
                    {"23456", "$12.50"}
                };
                if (barcode == "12345")
                    display.Text = lookupTable[barcode];
                else if (barcode == "23456")
                    display.Text = lookupTable[barcode];
                else
                    display.Text = "Product not found for " + barcode;
            }
        }
    }
}
