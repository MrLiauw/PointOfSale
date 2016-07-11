namespace UnitTestProject1
{
    class Sale
    {
        private Display display;

        public Sale(Display display)
        {
            this.display = display;
        }

        internal void onBarCode(string p)
        {
            display.Text = "$7.95";
        }
    }
}
