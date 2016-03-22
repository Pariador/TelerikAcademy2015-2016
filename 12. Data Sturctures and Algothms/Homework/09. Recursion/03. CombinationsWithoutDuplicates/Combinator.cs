namespace Combinations
{
	using System;

	public class Combinator
	{
		public Combinator(int comboLength, int setLength)
		{
			this.CurrentCombo = new int[comboLength];
			this.SetLength = setLength;
		}

		private int[] CurrentCombo { get; set; }

		public int SetLength { get; private set; }

		private void PrintCombination(int startValue, int comboIndex)
		{
			if (comboIndex >= this.CurrentCombo.Length)
			{
				Console.WriteLine(string.Join(", ", this.CurrentCombo));
				return;
			}

			for (int value = startValue; value <= this.SetLength; value++)
			{
				this.CurrentCombo[comboIndex] = value;
				this.PrintCombination(value + 1, comboIndex + 1);
			}
		}

		public void PrintAllCombinations()
		{
			this.PrintCombination(1, 0);
		}
	}
}