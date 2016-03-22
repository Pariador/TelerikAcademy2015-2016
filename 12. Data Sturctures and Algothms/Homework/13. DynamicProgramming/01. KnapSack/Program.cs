namespace KnapSack
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public static class Program
	{
		public static ProductSack FindMostExpensiveProductSack(IEnumerable<Product> products, int sackLimit)
		{
			var sacks = new HashSet<ProductSack>();
			var newSacks = new HashSet<ProductSack>();

			foreach (var product in products)
			{
				foreach (var sack in sacks)
				{
					if (!sack.CanAddProduct(product))
					{
						continue;
					}
					ProductSack newSack = sack.Clone();

					newSack.AddProduct(product);
					newSacks.Add(newSack);
				}

				sacks.UnionWith(newSacks);
				newSacks.Clear();

				sacks.Add(new ProductSack(sackLimit).AddProduct(product));
			}

			ProductSack mostExpensiveSack = sacks.Max();

			return mostExpensiveSack;
		}

		public static void Main()
		{
			const int WeightLimit = 10;

			Product[] products =
			{
				new Product(3, 2),
				new Product(8, 12),
				new Product(4, 5),
				new Product(1, 4),
				new Product(2, 3),
				new Product(8, 13)
			};


			ProductSack result = FindMostExpensiveProductSack(products, WeightLimit);
			Console.WriteLine(result);
		}
	}
}