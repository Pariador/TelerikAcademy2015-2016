namespace Teleimot.Services
{
	using System.Linq;

	using Data.Models;

	public interface ICommentService
	{
		IQueryable<Comment> All();

		IQueryable<Comment> AllSkipTake(int skip, int take);

		IQueryable<Comment> GetCommentsForUser(string userName, int skip, int take);

		Comment Add(string userId, int estateId, string content);
	}
}