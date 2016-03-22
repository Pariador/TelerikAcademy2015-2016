namespace Exam.Data.Models
{
	using Common;
	using System.ComponentModel.DataAnnotations;

	public class Rating
	{
		public int Id { get; set; }

		[Range(ValidationConstants.MinRatingValue, ValidationConstants.MaxRatingValue)]
		public int Value { get; set; }

		[Required]
		public string UserId { get; set; }

		public virtual User User { get; set; }

		public int PlaylistId { get; set; }

		public virtual Playlist Playlist { get; set; }
	}
}