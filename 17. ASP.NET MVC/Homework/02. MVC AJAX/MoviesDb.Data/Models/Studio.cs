namespace MoviesDb.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Studio
	{
		private ICollection<Movie> movies;

		public Studio()
		{
			this.movies = new HashSet<Movie>();
		}

		public int Id { get; set; }

		[Required]
		[MaxLength(ValidationConstants.StudioNameMaxLength)]
		public string Name { get; set; }

		[MaxLength(ValidationConstants.StudioAddressMaxLength)]
		public string Address { get; set; }

		public virtual ICollection<Movie> Movies
		{
			get
			{
				return this.movies;
			}

			set
			{
				this.movies = value;
			}
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}