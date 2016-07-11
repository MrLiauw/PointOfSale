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
            if (barcode == "12345")
                display.Text = "$7.95";
            else if(barcode == "23456")
                display.Text = "$12.50";
            else
                display.Text = "Product not found for " + barcode;
        }
    }
}
