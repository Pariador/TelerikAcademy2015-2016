namespace Teleimot.Web.Api.Controllers
{
	using System.Linq;
	using System.Web.Http;
	using Microsoft.AspNet.Identity;

	using Services;
	using Data.Models;
	using Models.Users;

	public class UsersController : ApiController
	{
		public UsersController(IUserService userService)
		{
			this.UserService = userService;
		}

		public UsersController()
			: this(new UserService())
		{

		}

		private IUserService UserService { get; set; }

		[HttpGet]
		[Route("api/Users/{userName}")]
		public IHttpActionResult Get(string userName)
		{
			var details = this.UserService.GetUserDetails(userName);

			double rating = details.Rating == null ? 0 : (double)details.Rating;

			var response = new UserDetailsResponseModel
			{
				UserName = details.UserName,
				RealEstates = details.EstatesCount,
				Comments = details.CommentsCount,
				Rating = rating
			};

			return this.Ok(response);
		}

		[HttpPut]
		[Authorize]
		[Route("api/Users/Rate")]
		public IHttpActionResult Rate(UserRatingRequestModel model)
		{
			if (!this.ModelState.IsValid || model.UserId == User.Identity.GetUserId())
			{
				return this.BadRequest();
			}

			this.UserService.Rate(model.UserId, model.Value);

			return this.Ok();
		}
	}
}