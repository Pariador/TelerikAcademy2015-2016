namespace FriendsOfPesho
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public static class Program
	{
		public static int CalcMinDistance(int from, int to, Dictionary<int, List<Street>> buildings)
		{
			return 0;
		}

		public static void Main()
		{
			int[] firstLineData = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();

			int buildingsCount = firstLineData[0];
			int streetsCount = firstLineData[1];
			int hospitalsCount = firstLineData[2];

			int[] hospitals = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();

			var buildings = new Dictionary<int, List<Street>>();

			for (int i = 0; i < streetsCount; i++)
			{
				int[] data = Console.ReadLine()
					.Split(' ')
					.Select(int.Parse)
					.ToArray();

				int from = data[0];
				int to = data[1];
				int distance = data[2];

				if (!buildings.ContainsKey(from))
				{
					buildings[from] = new List<Street>();
				}

				Street street = new Street(to, distance);
				buildings[from].Add(street);


			}

			int[] totalDistanceFromHospitals = new int[hospitals.Length];

			for (int i = 0; i < hospitals.Length; i++)
			{
				totalDistanceFromHospitals[i] = 0;

				foreach (var building in buildings)
				{
					if (!hospitals.Contains(building.Key))
					{
						totalDistanceFromHospitals[i] += CalcMinDistance(hospitals[i], building.Key, buildings);
					}
				}
			}

			Console.WriteLine(totalDistanceFromHospitals.Min());
		}
	}
}