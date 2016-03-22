namespace Teleimot.Services
{
	using System.Linq;

	using Data;
	using Data.Models;

	public class UserService : IUserService
	{
		public UserService(IRepository<User> users)
		{
			this.Users = users;
		}

		public UserService()
			: this(new TeleimotRepository<User>())
		{
			
		}

		private IRepository<User> Users { get; set; } 

		public IQueryable<User> All()
		{
			return this.Users.All();
		}

		public User GetById(string id)
		{
			return this.Users.GetById(id);
		}

		public UserDetails GetUserDetails(string userName)
		{
			return this.Users.All()
				.Select(user => new UserDetails	
				{
					UserName = user.UserName,
					EstatesCount = user.Esatates.Count,
					CommentsCount = user.Comments.Count,
					Rating = user.Ratings.Select(r => r.Rating).Average(b => b)
				})
				.FirstOrDefault(details => details.UserName == userName);
		}

		public void Rate(string userId, byte rating)
		{
			UserRating userRating = new UserRating
			{
				UserId = userId,
				Rating = rating
			};

			User user = this.Users.GetById(userId);

			user.Ratings.Add(userRating);

			this.Users.SaveChanges();
		}

		public IQueryable<User> TopTen()
		{
			return this.Users.All()
				.OrderByDescending(user => user.Ratings.Select(r => r.Rating).Average(b => b))
				.Take(10);
		}
	}
}