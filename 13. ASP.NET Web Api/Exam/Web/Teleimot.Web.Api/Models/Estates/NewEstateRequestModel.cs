namespace Teleimot.Web.Api.Models.Estates
{
	using System.ComponentModel.DataAnnotations;

	using Common.Data;

	public class NewEstateRequestModel
	{
		[Required]
		[MinLength(ValidationConstraints.EstateTitleMinLength)]
		[MaxLength(ValidationConstraints.EstateTitleMaxLength)]
		public string Title { get; set; }

		[Required]
		[MinLength(ValidationConstraints.EstateDescriptionMinLenth)]
		[MaxLength(ValidationConstraints.EstateDescriptionMaxLenth)]
		public string Description { get; set; }

		[Required]
		public string Address { get; set; }


		[Required]
		public string Contact { get; set; }

		[Range(ValidationConstraints.EstateConstructionYearMin, int.MaxValue)]
		public int ConstructionYear { get; set; }

		public decimal? SellingPrice { get; set; }

		public decimal? RentingPrice { get; set; }

		public EstateType Type { get; set; }
	}
}