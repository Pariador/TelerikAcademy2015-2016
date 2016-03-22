namespace Adapter
{
    public class NewWriterAdapter : IWirter
    {
        public NewWriterAdapter()
        {
            this.Writer = new NewWriter(); 
        }

        private NewWriter Writer { get; set; }

        public IWirter IWirter
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public NewWriter NewWriter
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Write(string text)
        {
            this.Writer.Print(text);
        }
    }
}