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
            else
                display.Text = "$12.50";
        }
    }
}
