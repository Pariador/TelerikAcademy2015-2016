namespace InfoSite.Data.Models
{
	public class Algorithm
	{
		private static int NextId { get; set; }

		public Algorithm()
		{
			this.Id = Algorithm.NextId++;
		}

		public int Id { get; }

		public string Name { get; set; }

		public Category Category { get; set; }

		public string Author { get; set; }

		public string Summary { get; set; }

		public string Description { get; set; }

		public string PseudoCode { get; set; }

		public string ImageUrl { get; set; }

		public double Rating { get; set; }
	}
}