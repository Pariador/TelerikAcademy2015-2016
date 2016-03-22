namespace Articles
{
	using System;

	using Wintellect.PowerCollections;

	public static class Program
	{
		private static readonly Random Rand = new Random();

		public static void Main()
		{
			var articles = new OrderedMultiDictionary<decimal, Article>(false);

			for (int i = 0; i < 1000; i++)
			{
				Article article = new Article
				{
					Title = "Some Article" + i,
					Vendor = "Koko Poko" + i,
					Barcode = "231512432#" + i,
					Price = ((decimal)Program.Rand.NextDouble() + Program.Rand.Next(101))
				};

				articles.Add(article.Price, article);
			}

			var articlesInRange = articles.Range(20, true, 80, true);

			foreach (var articleCollection in articlesInRange)
			{
				foreach (var article in articleCollection.Value)
				{
					Console.WriteLine(article);
				}
			}
		}
	}
}