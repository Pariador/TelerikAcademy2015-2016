using System;
using System.Net;

//Problem 4. Download file
//Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
//Find in Google how to download files in C#.
//Be sure to catch all exceptions and to free any used resources in the finally block.
class DownloadFileTest
{
    static void Main()
    {
        try
        {
            using (WebClient Client = new WebClient())
            {
                Console.Write("Input URL: ");
                string url = Console.ReadLine();

                Console.Write("\nInput file name: ");
                string fileName = Console.ReadLine();

                Client.DownloadFile(url, fileName);
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("\nInvalid input.\n");
        }
        catch (WebException)
        {
            Console.WriteLine("\nNetwork error.\n");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("\nDownload file not supported.\n");
        }
        catch (Exception)
        {
            throw;
        }
    }
}