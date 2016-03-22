namespace MvcTemplate.Web.Controllers
{
	using System;
	using System.Linq;
	using System.Web.Mvc;

	using Data.Common;
    using Data.Models;
    using Services.Data;
    using ViewModels.Home;

	using Common;
	using Infrastructure.Mapping;
    using ViewModels.Ideas;

	public class HomeController : BaseController
    {
		public IDbRepository<Idea> Ideas { get; set; }

		public HomeController(IDbRepository<Idea> ideas)
		{
			this.Ideas = ideas;
		}


		public ActionResult Index(HomeViewModel model)
        {
			this.ViewBag.Success = this.TempData[TempDataKeys.Success] as string;
			this.ViewBag.Error = this.TempData[TempDataKeys.Error] as string;

			const int PageSize = 3;

			if (model.CurrentPage < 1)
			{
				model.CurrentPage = 1;
			}

			//model.PageCount = (int)Math.Ceiling((double)this.Ideas.All().Count() / PageSize);

			var ideas = this.Ideas.All()
				;

			if (!string.IsNullOrEmpty(model.Filter))
			{
				ideas = ideas.Where(idea => idea.Content.Contains(model.Filter) || idea.Title.Contains(model.Filter));
			}

			if (model.OrderBy == OrederByOptions.Date)
			{
				ideas = ideas.OrderByDescending(idea => idea.CreatedOn);
			}
			else
			{
				ideas = ideas.OrderByDescending(idea => idea.Votes.Sum(vote => vote.VotePoints));
			}

			model.Ideas = ideas.Page(model.CurrentPage, PageSize)
				.Select(idea => new IdeaViewModel
				{
					Title = idea.Title,
					Content = idea.Content.Replace("\r\n", "<br>").Replace("\n", "<br>"),
					VotesCount = idea.Votes.DefaultIfEmpty()
						.Sum(vote => vote == null ? 0 : vote.VotePoints)
				});

            return this.View(model);
        }
    }
}
