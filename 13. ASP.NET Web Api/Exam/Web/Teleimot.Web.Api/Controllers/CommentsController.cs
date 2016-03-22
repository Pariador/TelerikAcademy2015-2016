namespace Teleimot.Web.Api.Controllers
{
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Web.Http;
	using Microsoft.AspNet.Identity;

	using Services;
	using Data.Models;
	using Models.Comments;

	public class CommentsController : ApiController
	{
		private static readonly Expression<Func<Comment, NormalCommentResponseModel>> NormalCommentCreate = comment => new NormalCommentResponseModel
		{
			Content = comment.Content,
			UserName = comment.User.UserName,
			CreatedOn = comment.CreatedOn
		};

		public CommentsController(ICommentService commentService)
		{
			this.CommentService = commentService;
		}

		public CommentsController()
			: this(new CommentService())
		{

		}

		private ICommentService CommentService { get; set; }

		public IHttpActionResult Get(int skip = ApiConstants.DefaultSkip, int take = ApiConstants.DefaultTake)
		{
			if (take > ApiConstants.MaxTake)
			{
				return this.BadRequest("Take can't be more than " + ApiConstants.MaxTake);
			}

			var response = this.CommentService.AllSkipTake(skip, take)
				.Select(CommentsController.NormalCommentCreate);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("api/comments/ByUser/{userName}")]
		public IHttpActionResult ByUser(string userName, int skip = ApiConstants.DefaultSkip, int take = ApiConstants.DefaultTake)
		{
			if (take > ApiConstants.MaxTake)
			{
				return this.BadRequest("Take can't be more than " + ApiConstants.MaxTake);
			}

			var response = this.CommentService.GetCommentsForUser(userName, skip, take)
				.Select(CommentsController.NormalCommentCreate);

			return this.Ok(response);
		}

		[Authorize]
		public IHttpActionResult Post(NewCommentRequestModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.BadRequest();
			}

			string userId = this.User.Identity.GetUserId();

			Comment comment = this.CommentService.Add(userId: userId, estateId: model.RealEstateId, content: model.Content);

			var response = this.CommentService.All()
				.Where(com => com.Id == comment.Id)
				.Select(CommentsController.NormalCommentCreate)
				.FirstOrDefault();

			return this.Created(comment.Id.ToString(), response);
		}
	}
}