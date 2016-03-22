namespace InfoSite.Data.Models
{
	public class Category
	{
		private static int NextId { get; set; }

		public Category()
		{
			this.Id = Category.NextId++;
		}

		public int Id { get; }

		public string Name { get; set; }
	}
}