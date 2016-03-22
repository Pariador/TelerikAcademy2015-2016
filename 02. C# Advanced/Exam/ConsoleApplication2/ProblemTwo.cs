using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections.Generic;

class ProblemTwo
{
    static bool checkSeq(List<int> sequence)
    {
        int diference = 0;
        for (int element = 1; element < sequence.Count; element++)
        {
            diference = Math.Max(sequence[element], sequence[element - 1]) - Math.Min(sequence[element], sequence[element - 1]);
            if ((diference != 0 && diference != 1) || (sequence[element] > sequence[element - 1]))
            {
                return false;
            }
        }

        return true;
    }
    static void Main()
    {
        int lineCount = int.Parse(Console.ReadLine());
        int[][] sequnces = new int[lineCount][];
        bool[] result = new bool[lineCount];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = true;
        }

        for (int i = 0; i < sequnces.Length; i++)
        {
            sequnces[i] = Console.ReadLine().Split(new char[]{' ', '\n', '\r' , '\t'}, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse).ToArray();
        }

        var betweenSeq = new List<int>[sequnces.Length];
        for (int i = 0; i < betweenSeq.Length; i++)
        {
            betweenSeq[i] = new List<int>();
        }
        //bool isRight = true;
        int diference = 0;
        for (int i = 0; i < sequnces.Length; i++)
        {
            for (int element = 1; element < sequnces[i].Length; element++)
            {
                diference = Math.Max(sequnces[i][element], sequnces[i][element-1]) - Math.Min(sequnces[i][element], sequnces[i][element-1]);
                betweenSeq[i].Add(diference);
            }
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = checkSeq(betweenSeq[i]);
        }

        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }
    }
}