namespace Teleimot.Services
{
	using System.Linq;

	using Data;
	using Data.Models;


	public class CommentService : ICommentService
	{
		public CommentService(IRepository<Comment> comments)
		{
			this.Comments = comments;
		}

		public CommentService()
			: this(new TeleimotRepository<Comment>())
		{
			
		}

		private IRepository<Comment> Comments { get; set; }

		public IQueryable<Comment> All()
		{
			return this.Comments.All();
		}

		public IQueryable<Comment> AllSkipTake(int skip, int take)
		{
			return this.Comments.All()
				.OrderByDescending(estate => estate.CreatedOn)
				.Skip(skip)
				.Take(take);
		}

		public IQueryable<Comment> GetCommentsForUser(string userName, int skip, int take)
		{
			return this.Comments.All()
				.Where(comment => comment.User.UserName == userName)
				.OrderByDescending(estate => estate.CreatedOn)
				.Skip(skip)
				.Take(take);
		}

		public Comment Add(string userId, int estateId, string content)
		{
			Comment comment = new Comment
			{
				UserId =  userId,
				EstateId = estateId,
				Content = content
			};

			this.Comments.Add(comment);

			this.Comments.SaveChanges();

			return  comment;
		}
	}
}