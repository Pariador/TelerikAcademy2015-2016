namespace Teleimot.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	using Common.Data;

	public class Estate
	{
		private ICollection<Comment> comments;

		public Estate()
		{
			this.comments = new HashSet<Comment>();

			this.CreatedOn = DateTime.Now;
		}

		public int Id { get; set; }

		public DateTime CreatedOn { get; set; }

		[Required]
		[MinLength(ValidationConstraints.EstateTitleMinLength)]
		[MaxLength(ValidationConstraints.EstateTitleMaxLength)]
		public string Title { get; set; }

		[Required]
		[MinLength(ValidationConstraints.EstateDescriptionMinLenth)]
		[MaxLength(ValidationConstraints.EstateDescriptionMaxLenth)]
		public string Description { get; set; }

		public EstateType Type { get; set; }

		[Required]
		public string Address { get; set; }

		[Range(ValidationConstraints.EstateConstructionYearMin, int.MaxValue)]
		public int ConstructionYear { get; set; }

		public decimal? RentingPrice { get; set; }

		public decimal? SellingPrice { get; set; }

		[Required]
		public string UserId { get; set; }

		public virtual User User { get; set; } 

		[Required]
		public string Contact { get; set; }

		public virtual ICollection<Comment> Comments
		{
			get
			{
				return this.comments;
			}

			set
			{
				this.comments = value;
			}
		}
	}
}