namespace Teleimot.Web.Api.Models.Estates
{
	using System.ComponentModel.DataAnnotations;

	using Data.Models;

	using Common.Data;

	public class NormalEstateResponseModel
	{
		protected NormalEstateResponseModel(Estate estate)
		{
				this.Id = estate.Id;
				this.Title = estate.Title;
				this.SellingPrice = estate.SellingPrice;
				this.RentingPrice = estate.RentingPrice;
				this.CanBeSold = estate.SellingPrice != null;
				this.CanBeRented = estate.RentingPrice != null;
        }

		public int Id { get; set; }

		[Required]
		[MinLength(ValidationConstraints.EstateTitleMinLength)]
		[MaxLength(ValidationConstraints.EstateTitleMaxLength)]
		public string Title { get; set; }

		public decimal? SellingPrice { get; set; }

		public decimal? RentingPrice { get; set; }

		public bool CanBeSold { get; set; }

		public bool CanBeRented { get; set; }

		public static NormalEstateResponseModel Create(Estate estate)
		{
			return new NormalEstateResponseModel(estate);
		}
	}
}