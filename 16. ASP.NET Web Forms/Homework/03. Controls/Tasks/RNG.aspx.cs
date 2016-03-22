namespace Tasks
{
	using System;
	using System.Web.UI;

	public partial class RNG : Page
	{
		protected void Randomize(object sender, EventArgs args)
		{
			int min = int.Parse(this.min.Text);
			int max = int.Parse(this.max.Text);

			int result = Randomizer.Random.Next(min, max + 1);


			this.result.Text = result.ToString();
		}
	}
}