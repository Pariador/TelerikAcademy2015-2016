using System;

class ZeroSubset
{
    static void Main()
    {
        int[] numbers = new int[5];

        //Input the five numbers.
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Input number {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        bool found = false;
        //Goes through every combination of 2, 3 and 4 numbers and if it totals 0, prints it.
        for (int i = 0; i < 4; i++)
        {
            for (int y = i + 1; y < 5; y++)
            {
                if (numbers[i] + numbers[y] == 0)
                {
                    found = true;
                    Console.WriteLine("\n{0}({1}) + {2}({3}) = 0", numbers[i], i + 1, numbers[y], y + 1);
                }

                if (i < 3)
                {
                    for (int t = y + 1; t < 5; t++)
                    {
                        if (numbers[i] + numbers[y] + numbers[t] == 0)
                        {
                            found = true;
                            Console.WriteLine("\n{0}({1}) + {2}({3}) + {4}({5}) = 0", numbers[i], i + 1, numbers[y], y + 1, numbers[t], t + 1);
                        }

                        if (i < 2)
                        {
                            for (int q = t + 1; q < 5; q++)
                            {
                                if (numbers[i] + numbers[y] + numbers[t] + numbers[q] == 0)
                                {
                                    found = true;
                                    Console.WriteLine("\n{0}({1}) + {2}({3}) + {4}({5}) + {6}({7}) = 0", numbers[i], i + 1, numbers[y], y + 1, numbers[t], t + 1, numbers[q], q + 1);
                                }
                            }
                        }
                    }
                }
            }
        }

        //A check for all five numbers.
        if (numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4] == 0)   //check for all five
        {
            found = true;
            Console.WriteLine("\n{0}(1) + {1}(2) + {2}(3) + {3}(4) + {4}(5) = 0", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
        }

        if (found == true)
        {
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("\nNo zero subset.\n");
        }
    }
}