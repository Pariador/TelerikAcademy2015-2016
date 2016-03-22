namespace Adapter
{
    using System;

    public class OldWriter : IWirter
    {
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
    
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}