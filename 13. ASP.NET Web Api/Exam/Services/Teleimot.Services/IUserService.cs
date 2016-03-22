namespace Teleimot.Services
{
	using System.Linq;

	using Data.Models;

	public interface IUserService
	{
		IQueryable<User> All();

		User GetById(string id);

		UserDetails GetUserDetails(string userName);

		void Rate(string userId, byte rating);

		IQueryable<User> TopTen();
	}
}