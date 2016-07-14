namespace UnitTestProject1
{
    class Display
    {
        public string Text;

        internal object getText()
        {
            return Text;
        }

        public void DisplayNotFoundMessage(string barcode)
        {
            Text = "Product not found for " + barcode;
        }

        public void DisplayPrice(string priceAsText)
        {
            Text = priceAsText;
        }

        public void DisplayEmptyBarcodeMessage()
        {
            Text = "Scanning error : empty barcode";
        }
    }
}
