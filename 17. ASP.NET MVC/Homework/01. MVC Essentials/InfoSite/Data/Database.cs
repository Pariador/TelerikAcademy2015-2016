namespace InfoSite.Data
{
	using System.IO;
	using System.Collections.Generic;

	using Common;
	using Models;

	public static class Database
	{
		static Database()
		{
			Database.Algorithms = new List<Algorithm>();
			Database.Categories = new List<Category>();
		}

		public static List<Algorithm> Algorithms { get; }

		public static List<Category> Categories { get; }

		public static void Seed(string dataPath)
		{
			string code = File.ReadAllText(dataPath + "/code.c");

			for (int i = 0; i < 30; i++)
			{
				Category category = new Category
				{
					Name = RandomGenerator.GetString(5, 10)
				};

				Database.Categories.Add(category);
			}

			for (int i = 0; i < 15; i++)
			{
				Algorithm algorithm = new Algorithm
				{
					Name = RandomGenerator.GetString(3, 20),
					Category = RandomGenerator.GetFrom(Database.Categories),
					Author = RandomGenerator.GetString(3, 10) + " " + RandomGenerator.GetString(3, 10),
					Summary = RandomGenerator.GetString(20, 120),
					Description = RandomGenerator.GetString(50, 200),
					PseudoCode = code,
					ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5d/Breadth-First-Search-Algorithm.gif",
					Rating = RandomGenerator.GetInt(1, 10)
				};

				Database.Algorithms.Add(algorithm);
			}
		}
	}
}