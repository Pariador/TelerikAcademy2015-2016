namespace StringsSubset
{
	using System;

	public class StringCombinator
	{
		public StringCombinator(int comboLength, string[] strings)
		{
			this.CurrentCombo = new string[comboLength];
			this.Strings = strings;
		}

		private string[] CurrentCombo { get; set; }

		private string[] Strings { get; set; }

		private void PrintCombination(int startIndex, int comboIndex)
		{
			if (comboIndex >= this.CurrentCombo.Length)
			{
				Console.WriteLine(string.Join(", ", this.CurrentCombo));
				return;
			}

			for (int currentIndex = startIndex; currentIndex < this.Strings.Length; currentIndex++)
			{
				this.CurrentCombo[comboIndex] = this.Strings[currentIndex];
				this.PrintCombination(currentIndex + 1, comboIndex + 1);
			}
		}

		public void PrintAllCombinations()
		{
			this.PrintCombination(0, 0);
		}
	}
}