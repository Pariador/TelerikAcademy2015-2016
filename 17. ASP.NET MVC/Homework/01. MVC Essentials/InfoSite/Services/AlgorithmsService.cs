namespace InfoSite.Services
{
	using System.Linq;
	using System.Collections.Generic;

	using Data;
	using Data.Models;

	public class AlgorithmsService
	{
		public IEnumerable<Algorithm> All()
		{
			return Database.Algorithms;
		}

		public Algorithm GetById(int id)
		{
			return Database.Algorithms.Find(algo => algo.Id == id);
		}

		public Algorithm Add(Algorithm algorithm)
		{
			Database.Algorithms.Add(algorithm);

			return algorithm;
		}

		public IEnumerable<Algorithm> GetTop(int count)
		{
			var res =  Database.Algorithms.OrderByDescending(algo => algo.Rating)
				.Take(count);

			return res;
		}
	}
}