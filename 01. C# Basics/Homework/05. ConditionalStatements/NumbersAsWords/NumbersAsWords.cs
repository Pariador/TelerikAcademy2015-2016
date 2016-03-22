using System;
class NumbersAsWords
{
    static void Main()
    {
        //Input a number.
        Console.Write("Input a number between 0 and 999: ");
        int number = int.Parse(Console.ReadLine());

        if (number < 0 || number > 999)
        {
            Console.WriteLine("\nNumber out of range.\n");
            return;
        }

        //Initialize unique words.
        string[] unitsWords = new string[]
        {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
         "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

        string[] tensWords = new string[] {"Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};


        //Checks if the number fits a unique word and if not, constructs a string fitting the number based on the count and values of its digits.
        if (number < 20)
        {
            switch (number)
            {
                case 0:
                    Console.WriteLine("\n{0}.\n", unitsWords[0]);
                    break;
                case 1:
                    Console.WriteLine("\n{0}.\n", unitsWords[1]);
                    break;
                case 2:
                    Console.WriteLine("\n{0}.\n", unitsWords[2]);
                    break;
                case 3:
                    Console.WriteLine("\n{0}.\n", unitsWords[3]);
                    break;
                case 4:
                    Console.WriteLine("\n{0}.\n", unitsWords[4]);
                    break;
                case 5:
                    Console.WriteLine("\n{0}.\n", unitsWords[5]);
                    break;
                case 6:
                    Console.WriteLine("\n{0}.\n", unitsWords[6]);
                    break;
                case 7:
                    Console.WriteLine("\n{0}.\n", unitsWords[7]);
                    break;
                case 8:
                    Console.WriteLine("\n{0}.\n", unitsWords[8]);
                    break;
                case 9:
                    Console.WriteLine("\n{0}.\n", unitsWords[9]);
                    break;
                case 10:
                    Console.WriteLine("\n{0}.\n", unitsWords[10]);
                    break;
                case 11:
                    Console.WriteLine("\n{0}.\n", unitsWords[11]);
                    break;
                case 12:
                    Console.WriteLine("\n{0}.\n", unitsWords[12]);
                    break;
                case 13:
                    Console.WriteLine("\n{0}.\n", unitsWords[13]);
                    break;
                case 14:
                    Console.WriteLine("\n{0}.\n", unitsWords[14]);
                    break;
                case 15:
                    Console.WriteLine("\n{0}.\n", unitsWords[15]);
                    break;
                case 16:
                    Console.WriteLine("\n{0}.\n", unitsWords[16]);
                    break;
                case 17:
                    Console.WriteLine("\n{0}.\n", unitsWords[17]);
                    break;
                case 18:
                    Console.WriteLine("\n{0}.\n", unitsWords[18]);
                    break;
                case 19:
                    Console.WriteLine("\n{0}.\n", unitsWords[19]);
                    break;
                default:
                    Console.WriteLine("\nError first switch!\n");
                    break;
            }
        }
        else if (number <= 100 && number % 10 == 0)
        {
            switch (number)
            {
                case 20:
                    Console.WriteLine("\n{0}.\n", tensWords[2]);
                    break;
                case 30:
                    Console.WriteLine("\n{0}.\n", tensWords[3]);
                    break;
                case 40:
                    Console.WriteLine("\n{0}.\n", tensWords[4]);
                    break;
                case 50:
                    Console.WriteLine("\n{0}.\n", tensWords[5]);
                    break;
                case 60:
                    Console.WriteLine("\n{0}.\n", tensWords[6]);
                    break;
                case 70:
                    Console.WriteLine("\n{0}.\n", tensWords[7]);
                    break;
                case 80:
                    Console.WriteLine("\n{0}.\n", tensWords[8]);
                    break;
                case 90:
                    Console.WriteLine("\n{0}.\n", tensWords[9]);
                    break;
                case 100:
                    Console.WriteLine("\nOne hundred.\n");
                    break;
                default:
                    Console.WriteLine("\nError second switch!\n");
                    break;
            }
        }
        else 
        {
            //Counts the digits.
            int digitCount = 0;
            int holdNum = number;
            
            while (holdNum != 0)
            {
                digitCount++;
                holdNum /= 10;
            }

            //Saves each digit in the array.
            int[] digits = new int[digitCount];
            holdNum = number;

            for (int i = 0; i < digitCount; i++)
            {
                digits[i] = holdNum % 10;
                holdNum /= 10;
            }

            //Based on the digit count and digit values prints an appropriate string.
            if (digitCount == 2)
            {
                Console.WriteLine("\n{0} {1}.\n", tensWords[digits[1]], unitsWords[digits[0]]);
            }
            else 
            {
                if (digits[1] == 0)
                {
                    if (digits[0] == 0)
                    {
                        Console.WriteLine("\n{0} hundred.\n", unitsWords[digits[2]]);
                    }
                    else
                    {
                        Console.WriteLine("\n{0} hundred and {1}.\n", unitsWords[digits[2]], unitsWords[digits[0]]);
                    }
                }
                else if (digits[1] == 1)
                {
                    Console.WriteLine("\n{0} hundred and {1}.\n", unitsWords[digits[2]], unitsWords[10 + digits[0]]);
                }
                else
                {
                    Console.WriteLine("\n{0} hundred and {1} {2}.\n", unitsWords[digits[2]], tensWords[digits[1]], unitsWords[digits[0]]);
                }
            }
        }
    }
}