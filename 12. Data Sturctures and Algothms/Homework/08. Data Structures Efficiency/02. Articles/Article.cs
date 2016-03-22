namespace Articles
{
	using System;

	public class Article : IComparable<Article> 
	{
		public string Title { get; set; }

		public string Vendor { get; set; }

		public string Barcode { get; set; }

		public decimal Price { get; set; }

		public int CompareTo(Article other)
		{
			return this.Price.CompareTo(other.Price);
		}

		public override string ToString()
		{
			return string.Format("Price: {0:f2}; Title: {1}; Vendor: {2}; Barcode: {3};", this.Price, this.Title, this.Vendor, this.Barcode);
		}
	}
}