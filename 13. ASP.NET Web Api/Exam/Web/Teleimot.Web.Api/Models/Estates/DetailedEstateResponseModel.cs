namespace Teleimot.Web.Api.Models.Estates
{
	using System;
	using Data.Models;

	using Common.Data;

	public class DetailedEstateResponseModel : NormalEstateResponseModel
	{
		protected DetailedEstateResponseModel(Estate estate)
			: base(estate)
		{
			this.CreatedOn = estate.CreatedOn;
			this.ConstructionYear = estate.ConstructionYear;
			this.Address = estate.Address;
			this.RealEstateType = estate.Type;
			this.Description = estate.Description;
		}

		public DateTime CreatedOn { get; set; }

		public int ConstructionYear { get; set; }

		public string Address { get; set; }

		public EstateType RealEstateType { get; set; }

		public string Description { get; set; }

		public static new DetailedEstateResponseModel Create(Estate estate)
		{
			return new DetailedEstateResponseModel(estate);
		}
	}
}