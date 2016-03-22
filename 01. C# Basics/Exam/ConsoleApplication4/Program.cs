using System;

class Program
{
    static void Main()
    {
        int cols;
        int rows = cols = int.Parse(Console.ReadLine()) * 2 + 1;
        int space = int.Parse(Console.ReadLine()) + 1;

        int lefDiag = 0;
        int shapeTop = rows / 2 - space - 1;
        int shapeBot = rows / 2 + space + 1;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                lefDiag = rows - row - 1;

                if (col == cols / 2 && row == rows / 2)
                {
                    Console.Write('X');
                }
                else if (row == col)
                {
                    Console.Write('\\');
                }
                else if (col == lefDiag)
                {
                    Console.Write('/');
                }
                else if ((col < row && col < lefDiag) || (col > row && col > lefDiag))
                {
                    Console.Write('#');
                }
                else if (col == row + space && (row <= shapeTop) && (space * 2 < lefDiag - 1 - row))
                {
                    Console.Write('\\');
                }
                else if (col == lefDiag - space && (row <= shapeTop) && (space * 2 < lefDiag - 1 - row))
                {
                    Console.Write('/');
                }
                else if (col > row + space && col < lefDiag - space && (row <= shapeTop))
                {
                    Console.Write('.');
                }
                else if (col == lefDiag + space && (row >= shapeBot) && (space * 2 < row - lefDiag - 1))
                {
                    Console.Write('/');
                }
                else if (col == row - space && (row >= shapeBot) && (space * 2 < row - lefDiag - 1))
                {
                    Console.Write('\\');
                }
                else if (col > lefDiag + space && col < row - space && (row >= shapeBot))
                {
                    Console.Write('.');
                }
                else
                {
                    Console.Write(' ');
                }

            }
            Console.WriteLine();
        }
    }
}