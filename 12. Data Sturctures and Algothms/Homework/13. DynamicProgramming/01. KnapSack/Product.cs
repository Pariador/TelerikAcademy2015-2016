namespace KnapSack
{
	using System;

	public class Product
	{
		public Product(int weight, int cost)
		{
			this.Weight = weight;
			this.Cost = cost;
		}

		public int Cost { get; private set; }

		public int Weight { get; private set; }

		public static Product Parse(string str)
		{
			string[] data = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			int weight = int.Parse(data[0]);
			int cost = int.Parse(data[1]);

			return new Product(weight, cost);
		}
	}
}