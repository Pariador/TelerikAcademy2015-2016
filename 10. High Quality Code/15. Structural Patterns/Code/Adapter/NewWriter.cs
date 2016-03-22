namespace Adapter
{
    using System.IO;

    public class NewWriter
    {
    
        public void Print(string text)
        {
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                writer.WriteLine(text);
            }
        }
    }
}