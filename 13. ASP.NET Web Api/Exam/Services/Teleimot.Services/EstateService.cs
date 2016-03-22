namespace Teleimot.Services
{
	using System;
	using System.Linq;

	using Data;
	using Data.Models;
	using Common.Data;

	public class EstateService : IEstateService
	{
		public EstateService(IRepository<Estate> estates)
		{
			this.Estates = estates;
		}

		public EstateService()
			: this(new TeleimotRepository<Estate>())
		{
			;
		}

		private IRepository<Estate> Estates { get; set; }

		public IQueryable<Estate> All()
		{
			return this.Estates.All();	
		}

		public IQueryable<Estate> AllSkipTake(int skip, int take)
		{
			return this.Estates.All()
				.OrderByDescending(estate => estate.CreatedOn)
				.Skip(skip)
				.Take(take);
		}

		public Estate GetById(int id)
		{
			return this.Estates.GetById(id);
		}

		public Estate Add
		(
			string userId,
			string title,
			string description,
			string address,
			string contact,
			int constructionYear,
			decimal? sellingPrice,
			decimal? rentingPrice,
			EstateType type
		)
		{
			if (sellingPrice == null && rentingPrice == null)
			{
				throw new ArgumentException("SellingPrice and RentingPrice can't both be null");
			}

			Estate estate = new Estate()
			{
				UserId = userId,
				Title = title,
				Description = description,
				Address = address,
				Contact = contact,
				ConstructionYear = constructionYear,
				SellingPrice = sellingPrice,
				RentingPrice = rentingPrice,
				Type = type
			};

			this.Estates.Add(estate);

			this.Estates.SaveChanges();

			return estate;
		}
	}
}