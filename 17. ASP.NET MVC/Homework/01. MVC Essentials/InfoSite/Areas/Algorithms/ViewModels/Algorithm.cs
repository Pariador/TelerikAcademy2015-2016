namespace InfoSite.Areas.Algorithms.ViewModels
{
	public class Algorithm
	{
		public string Name { get; set; }

		public int CategoryId { get; set; }

		public string Author { get; set; }

		public string Summary { get; set; }

		public string Description { get; set; }

		public string PseudoCode { get; set; }

		public string ImageUrl { get; set; }

		public double Rating { get; set; }
	}
}