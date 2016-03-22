namespace Permuatations
{
	using System;

	public class Permutator
	{
		public Permutator(int setLength)
		{
			this.CurrentCombo = new int[setLength];
			this.SetLength = setLength;
			this.Used = new bool[setLength];
		}

		private int[] CurrentCombo { get; set; }

		private bool[] Used { get; set;}

		public int SetLength { get; private set; }

		private void PrintPermutation(int index)
		{
			if (index >= this.CurrentCombo.Length)
			{
				Console.WriteLine(string.Join(", ", this.CurrentCombo));
				return;
			}

			for (int value = 1; value <= this.SetLength; value++)
			{
				if (!this.Used[value - 1])
				{
					this.Used[value - 1] = true;
					this.CurrentCombo[index] = value;
					this.PrintPermutation(index + 1);
					this.Used[value - 1] = false;
				}
			}
		}

		public void PrintAllPermutations()
		{
			this.PrintPermutation(0);
		}
	}
}