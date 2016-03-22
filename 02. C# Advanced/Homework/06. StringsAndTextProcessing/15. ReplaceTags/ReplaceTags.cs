using System;
using System.Text;
//using System.Linq;

//Problem 15. Replace tags
//Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
class ReplaceTagsTest
{
    static void Main()
    {
        Console.WriteLine("Input HTML:");
        string html = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";// Console.ReadLine();

        var builder = new StringBuilder();
        bool atLink = false;
        string link = null;
        string betweebTags = null;
        int openIndex = -1;
        int closeIndex = -1;
        while (true)
        {
            openIndex = html.IndexOf("<a", openIndex + 1);

            if (openIndex == -1)
            {
                break;
            }

            for (int i = openIndex + 2; html[i] != '>'; i++)
            {
                if (html[i] == '"')
                {
                    atLink = !atLink;
                }
                else if (atLink)
                {
                    builder.Append(html[i]);
                }
            }

            link = builder.ToString();
            builder.Clear();

            closeIndex = html.IndexOf("</a>", closeIndex + 1);

            for (int i = closeIndex - 1; html[i] != '>'; i--)
            {
                builder.Insert(0, html[i]);
            }

            betweebTags = builder.ToString();
            builder.Clear();

            builder.Append(html.Remove(openIndex, closeIndex + 4 - openIndex));
            builder.Insert(openIndex, String.Format("[URL={0}]{1}[/URL]", link, betweebTags));
            html = builder.ToString();
            builder.Clear();
        }

        Console.WriteLine("Result:");
        Console.WriteLine("{0}\n", html);
    }
}