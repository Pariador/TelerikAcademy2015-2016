namespace Teleimot.Data.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	using Common.Data;

	public class Comment
	{
		public Comment()
		{
			this.CreatedOn = DateTime.Now;
		}

		public int Id { get; set; }

		[Required]
		[MinLength(ValidationConstraints.CommentContentMinLength)]
		[MaxLength(ValidationConstraints.CommentContentMaxLength)]
		public string Content { get; set; }

		public DateTime CreatedOn { get; set; }

		public int EstateId { get; set; }

		public virtual Estate Estate { get; set; }

		[Required]
		public string UserId { get; set; }

		public virtual User User { get; set; }
	}
}