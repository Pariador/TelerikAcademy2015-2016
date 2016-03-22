using System;
using System.Text;

//Problem 12. Parse URL
//Write a program that parses an URL address given in the format: 
//[protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
class ParseURLTest
{
    static void Main()
    {
        Console.Write("Input URL: ");
        string URL = Console.ReadLine();

        bool atProtocol = true;
        bool atServer = false;
        string protocol = null;
        string server = null;
        string resource = null;
        var builder = new StringBuilder();
        for (int i = 0; i < URL.Length; i++)
        {
            if (atProtocol)
            {
                if (URL[i] == ':')
                {
                    protocol = builder.ToString();
                    builder.Clear();
                    atProtocol = false;
                    atServer = true;
                    i += 2;
                    continue;
                }
                builder.Append(URL[i]);
            }
            else if(atServer)
            {
                if (URL[i] == '/')
                {
                    server = builder.ToString();
                    builder.Clear();
                    atServer = false;
                    continue;
                }
                builder.Append(URL[i]);
            }
            else
            {
                builder.Append(URL[i]);
            }
        }
        resource = builder.ToString();

        Console.WriteLine("\nProtocol: {0}", protocol);
        Console.WriteLine("\nServer: {0}", server);
        Console.WriteLine("\nResource: {0}\n", resource);
    }
}