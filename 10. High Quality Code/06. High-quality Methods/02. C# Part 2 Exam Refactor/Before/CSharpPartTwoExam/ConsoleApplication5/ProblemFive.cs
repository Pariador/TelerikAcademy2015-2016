using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections.Generic;

class ProblemFive
{
    static void Main()
    {
        int numberOfCats = int.Parse(Console.ReadLine().Split(' ')[0]);
        int numberOfSongs = int.Parse(Console.ReadLine().Split(' ')[0]);

        List<int>[] songs = new List<int>[numberOfSongs];

        for (int i = 0; i < songs.Length; i++)
        {
            songs[i] = new List<int>();
        }

        while (true)
        {
            string line = Console.ReadLine();

            if (line == "Mew!")
            {
                break;
            }

            string[] data = line.Split(' ');

            songs[int.Parse(data[4]) - 1].Add(int.Parse(data[1]));
        }

        for (int i = 0; i < songs.Length; i++)
        {
            if (songs[i].Count == 0)
            {
                songs[i] = null;
            }
        }

        List<int> finishedCats = new List<int>();
        int countSoungs = 0;
        while (finishedCats.Count != numberOfCats && songs.Any(sng => sng != null))
        {
            songs = songs.OrderByDescending(sng => 
            {
                if (sng == null)
	            {
		            return 0;
	            }

                return sng.Count;
            }).ToArray();

            finishedCats.AddRange(songs[0]);

            for (int i = 1; i < songs.Length; i++)
            {
                foreach (var cat in songs[0])
                {
                    if (songs[i] != null && songs[i].Contains(cat))
                    {
                        songs[i].Remove(cat);
                    }
                }
            }

            songs[0] = null;

            for (int i = 0; i < songs.Length; i++)
            {
                if (songs[i] != null && songs[i].Count == 0)
                {
                    songs[i] = null;
                }
            }
            countSoungs++;
        }

        if (finishedCats.Count == numberOfCats)
        {
            Console.WriteLine(countSoungs);
        }
        else
        {
            Console.WriteLine("No concert!");
        }
    }
}