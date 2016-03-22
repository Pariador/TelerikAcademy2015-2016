using System;
using System.IO;

//Problem 3. Read file contents
//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
//Find in MSDN how to use System.IO.File.ReadAllText(…).
//Be sure to catch all possible exceptions and print user-friendly error messages.
class ReadFileContentstTest
{
    static void Main()
    {
        //Gotta catch em all!
        
        try
        {
            Console.Write("Input file path: ");
            StreamReader reader = new StreamReader(Console.ReadLine());

            string text = null;
            using (reader)
            {
                text = reader.ReadToEnd();
            }

            Console.WriteLine("\nThe file contents: ");
            Console.Write("{0}\n\n", text);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("\nYou entered an empty path.\n");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("\nYou entered an invalid path.\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("\nYour file was not found.\n");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("\nDirectory was not found.\n");
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("\nYou appear to be out of memory, let me help you that.\n");
            System.Diagnostics.Process.Start("http://www.downloadmoreram.com/"); //Opens a link.
        }
        catch (IOException)
        {
            Console.WriteLine("\nSomething went wrong while trying to read the file.\n");
        }
        catch (Exception)
        {
            Console.WriteLine("\nMistakes were made.");
            Console.WriteLine("\nHouston we have a problem.");
            Console.WriteLine("\nERROR.");
            Console.WriteLine("\nInsecure world.");
            Console.WriteLine("\nShit happens.");
            Console.WriteLine("\nCatastrophic Failure.");
            Console.WriteLine("\n{Insert pointless undescriptive error here}");
            Console.WriteLine("\nAn error occurred while trying to display the previous error.\n");
        }
    }
}