namespace MoviesDb.Data.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class Movie
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(ValidationConstants.MoivieTitleMaxLength)]
		public string Title { get; set; }

		public DateTime ReleaseDate { get; set; }

		public int LeadingActorId { get; set; }

		public virtual Person LeadingActor { get; set; }

		public int DirectorId { get; set; }

		public virtual Person Director { get; set; }

		public int StudioId { get; set; }

		public virtual Studio Studio { get; set; }

		public override string ToString()
		{
			return this.Title;
		}
	}
}