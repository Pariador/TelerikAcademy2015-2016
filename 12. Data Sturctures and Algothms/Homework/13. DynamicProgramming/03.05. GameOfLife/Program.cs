namespace GameOfLife
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public static class Program
	{
		public static void PrintField(bool[,] field)
		{
			for (int row = 0; row < field.GetLength(0); row++)
			{
				for (int col = 0; col < field.GetLength(1); col++)
				{
					if (field[row, col])
					{
						Console.Write('1');
					}
					else
					{
						Console.Write('0');
					}
				}
				Console.WriteLine();
			}

			Console.WriteLine();
		}

		public static int CountLivingNeighbors(Position position, bool[,] field)
		{
			Position[] positionDiffs =
			{
				new Position(1, 0),
				new Position(-1, 0),

				new Position(0, 1),
				new Position(0, -1),

				new Position(1, 1),
				new Position(-1, -1),

				new Position(1, -1),
				new Position(-1, 1)
			};

			int count = 0;
			foreach (var diff in positionDiffs)
			{
				Position neighbor = position + diff;
				
				if (neighbor.IsValid(field) && field[neighbor.Row, neighbor.Col])
				{
					count++;
				}
			}

			return count;
		}

		public static bool DoesCellLive(Position position, bool[,] field)
		{
			int livingNeighborsCount = CountLivingNeighbors(position, field);

			if (livingNeighborsCount == 3)
			{
				return true;
			}

			if (livingNeighborsCount < 2 || livingNeighborsCount > 3)
			{
				return false;
			}

			return field[position.Row, position.Col];
		}

		public static bool[,] NextGeneration(Func<Position, bool[,], bool> gameEvent, bool[,] field)
		{
			bool[,] nextGen = (bool[,])field.Clone();

			for (int row = 0; row < field.GetLength(0); row++)
			{
				for (int col = 0; col < field.GetLength(1); col++)
				{
					Position position = new Position(row, col);

					nextGen[row, col] = gameEvent(position, field);
				}
			}

			return nextGen;
		}

		public static int CountLivingCells(bool[,] field)
		{
			int count = 0;

			for (int row = 0; row < field.GetLength(0); row++)
			{
				for (int col = 0; col < field.GetLength(1); col++)
				{
					if (field[row, col])
					{
						count++;
					}
				}
			}

			return count;
		}

		public static int GetSurvivorsCount(bool[,] field, int generationIndex)
		{
			Console.WriteLine("Initial:");
			//PrintField(field);
			Console.WriteLine();
			for (int i = 1; i <= generationIndex; i++)
			{
				field = NextGeneration(DoesCellLive, field);
				PrintField(field);
				Console.WriteLine();
			}

			return CountLivingCells(field);
		}

		public static void Main()
		{
			int generationIndex = int.Parse(Console.ReadLine());

			int[] rowsAndCols = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToArray();

			int rows = rowsAndCols[0];
			int cols = rowsAndCols[1];

			bool[,] field = new bool[rows, cols];
			for (int row = 0; row < rows; row++)
			{
				string[] colStr = Console.ReadLine()
					.Split(' ')
					.ToArray();

				for (int col = 0; col < cols; col++)
				{
					field[row, col] = colStr[col] == "1";
				}
			}

			Console.WriteLine(GetSurvivorsCount(field, generationIndex));
		}
	}
}