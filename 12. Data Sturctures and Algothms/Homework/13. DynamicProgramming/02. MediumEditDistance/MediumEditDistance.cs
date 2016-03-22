namespace MediumEditDistance
{
	using System.Linq;

	public static class MediumEditDistance
	{
		public const double InstertionCost = 0.8;

		public const double DeletionCost = 0.9;

		public const double SubstitutionCost = 1;

		public static double Calculate(string from, string to)
		{
			double[,] table = new double[from.Length, to.Length];

			for (var row = 0; row < table.GetLength(0); row++)
			{
				table[row, 0] = row * MediumEditDistance.DeletionCost;
			}

			for (var col = 0; col < table.GetLength(1); col++)
			{
				table[0, col] = col * MediumEditDistance.InstertionCost;
			}

			for (var row = 1; row < table.GetLength(0); row++)
			{
				for (var col = 1; col < table.GetLength(1); col++)
				{
					double[] costs =
					{
						table[row - 1, col - 1] + (from[row] == to[col] ? 0 : MediumEditDistance.SubstitutionCost),
						table[row, col - 1] + MediumEditDistance.InstertionCost,
						table[row - 1, col] + MediumEditDistance.DeletionCost
					};

					table[row, col] = costs.Min();
				}
			}

			return table[from.Length - 1, to.Length - 1];
		}
	}
}