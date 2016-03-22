namespace GameOfLife
{
	public struct Position
	{
		public Position(int row, int col)
		{
			this.Row = row;
			this.Col = col;
		}

		public int Row { get; set; }

		public int Col { get; set; }

		public bool IsValid<T>(T[,] matrix)
		{
			bool rowInRange = (0 <= this.Row) && (this.Row < matrix.GetLength(0));
			bool colInRange = (0 <= this.Col) && (this.Col < matrix.GetLength(1));

			return rowInRange && colInRange;
		}

		public bool Equals(Position other)
		{
			return this.Row == other.Row && this.Col == other.Col;
		}

		public override bool Equals(object obj)
		{
			if (obj is Position)
			{
				return this.Equals((Position)obj);
			}

			return false;
		}

		public override int GetHashCode()
		{
			return this.Row ^ this.Col;
		}

		public static Position operator +(Position first, Position second)
		{
			first.Row += second.Row;
			first.Col += second.Col;

			return first;
		}
	}
}