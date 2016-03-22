namespace Exam.Services
{
	using System.Linq;

	using Data;
	using Data.Models;
	using Data.Repositories;

	public class UsersService
	{
		private IRepository<User> users;

		public UsersService()
		{
			this.users = new GenericRepository<User>(new AppDbContext());
		}

		public User GetById(string id)
		{
			return this.users.All().FirstOrDefault(user => user.Id == id);
		}

		public void Update(User user)
		{
			this.users.Update(user);

			this.users.SaveChanges();
		}
	}
}