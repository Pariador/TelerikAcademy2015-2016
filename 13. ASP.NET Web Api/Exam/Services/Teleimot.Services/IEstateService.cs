namespace Teleimot.Services
{
	using System.Linq;

	using Data.Models;
	using Common.Data;

	public interface IEstateService
	{
		IQueryable<Estate> All();

		IQueryable<Estate> AllSkipTake(int skip, int take);

		Estate GetById(int id);

		Estate Add
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
		);
	}
}