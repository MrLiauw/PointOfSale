namespace UnitTestProject1
{
    class Display
    {
        public string Text { get; set; }

        internal object getText()
        {
            Text = "$7.95";
            return Text;
        }
    }
}
