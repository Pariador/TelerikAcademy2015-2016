namespace Variations
{
	using System;

	public class Variator
	{
		public Variator(string[] strings, int comboLength)
		{
			this.CurrentCombo = new string[comboLength];
			this.Strings = strings;
		}

		private string[] CurrentCombo { get; set; }

		public string[] Strings { get; private set; }

		private void PrintVariation(int index)
		{
			if (index >= this.CurrentCombo.Length)
			{
				Console.WriteLine(string.Join(", ", this.CurrentCombo));
				return;
			}

			for (int i = 0; i < this.Strings.Length; i++)
			{
				this.CurrentCombo[index] = this.Strings[i];
				this.PrintVariation(index + 1);
			}
		}

		public void PrintAllVariations()
		{
			this.PrintVariation(0);
		}
	}
}