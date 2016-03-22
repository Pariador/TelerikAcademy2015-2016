namespace Teleimot.Web.Api.Controllers
{
	using System.Linq;
	using System.Web.Http;
	using Microsoft.AspNet.Identity;

	using Services;
	using Data.Models;
	using Models.Estates;

	public class RealEstatesController : ApiController
	{
		public RealEstatesController(IEstateService estateService, IUserService userService)
		{
			this.EstateService = estateService;
			this.UserService = userService;
		}

		public RealEstatesController()
			: this(new EstateService(), new UserService())
		{
			
		}

		private IEstateService EstateService { get; set; }

		private IUserService UserService { get; set; }

		public IHttpActionResult Get(int skip = ApiConstants.DefaultSkip, int take = ApiConstants.DefaultTake)
		{
			if (take > ApiConstants.MaxTake)
			{
				return this.BadRequest("Take can't be more than " + ApiConstants.MaxTake);
			}

			var response = this.EstateService.AllSkipTake(skip, take)
				.Select(NormalEstateResponseModel.Create);

			return this.Ok(response);
		}

		public IHttpActionResult Get(int id)
		{
			if (!this.User.Identity.IsAuthenticated)
			{
				return this.Ok(this.EstateService.All()
					.Select(DetailedEstateResponseModel.Create)
					.FirstOrDefault());
			}

			var result = this.EstateService.All()
				.Select(estate => new
				{
					estate.Contact,
					Comments = estate.Comments.Select(com => new
					{
						com.Content,
						com.User.UserName,
						com.CreatedOn
					}),
					estate.CreatedOn,
					estate.ConstructionYear,
					estate.Address,
					RealEstateType = estate.Type,
					estate.Description,
					estate.SellingPrice,
					estate.RentingPrice,
					CanBeSold = estate.SellingPrice != null,
					CanBeRented = estate.RentingPrice != null
				})
				.FirstOrDefault();

			return this.Ok(result);
		}

		[Authorize]
		public IHttpActionResult Post(NewEstateRequestModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.BadRequest();
			}

			string userId = this.User.Identity.GetUserId();

			Estate estate = this.EstateService.Add
			(
				userId: userId,
				title: model.Title,
				description: model.Description,
				address: model.Address,
				contact: model.Contact,
				constructionYear: model.ConstructionYear,
				sellingPrice: model.SellingPrice,
				rentingPrice: model.RentingPrice,
				type: model.Type
			);

			var response = NormalEstateResponseModel.Create(estate);

			return this.Created(response.Id.ToString(), response);
		}
	}
}