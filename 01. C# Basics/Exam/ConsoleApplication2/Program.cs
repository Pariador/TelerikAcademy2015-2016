using System;

class Program
{
    static void Main()
    {
        double salt = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();

        double[] values = new double[text.Length];

        double hold = 0;
        char letter;
        int number;
        for (int i = 0; i < text.Length; i++)
        {
            hold = text[i];
            if ((hold >= 65 && hold <= 90) || (hold >= 97 && hold <= 122))
            {
                //hold = letter;
                values[i] = hold;
                values[i] = values[i] * salt + 1000;
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0:0.00}", values[i] / 100);
                }
                else
                {
                    Console.WriteLine(values[i] * 100);
                }
            }
            else if (int.TryParse(text[i].ToString(), out number))
            {
                hold = text[i];
                values[i] = hold;
                values[i] = values[i] + salt + 500;

                if (i % 2 == 0)
                {
                    Console.WriteLine("{0:0.00}", values[i] / 100);
                }
                else
                {
                    Console.WriteLine(values[i] * 100);
                }
            }
            else if (text[i] == '@')
            {
                return;
            }
            else
            {
                hold = text[i];
                values[i] = hold;
                values[i] = values[i] - salt;

                if (i % 2 == 0)
                {
                    Console.WriteLine("{0:0.00}", values[i] / 100);
                }
                else
                {
                    Console.WriteLine(values[i] * 100);
                }
            }
        }
    }
}