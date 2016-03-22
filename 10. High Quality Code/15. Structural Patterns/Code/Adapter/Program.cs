namespace Adapter
{
    using System;

    public static class Program
    {
        public static IWirter IWirter
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public static void Main()
        {
            //IWirter writer = new OldWriter();
            IWirter writer = new NewWriterAdapter();

            //This code doesn't need to change.
            writer.Write("Hello!");
        }
    }
}