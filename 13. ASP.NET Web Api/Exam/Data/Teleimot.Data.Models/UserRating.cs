namespace Teleimot.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Common.Data;

	public class UserRating
	{
		public int Id { get; set; }

		[Required]
		public string UserId { get; set; }

		public virtual User User { get; set; }

		[Range(ValidationConstraints.MinRating, ValidationConstraints.MaxRating)]
		public byte Rating { get; set; }
	}
}