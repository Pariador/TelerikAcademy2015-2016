namespace MvcTemplate.Web.Controllers
{
	using System.Linq;
	using System.Web.Mvc;
	using Data;
	using Data.Common;
	using Data.Models;
	using InputModels;

	public class VotesController : BaseController
	{
		public ApplicationDbContext Db { get; set; }

		public VotesController()
		{
			this.Db = new ApplicationDbContext();
			//this.Db = db;
		}

		public ActionResult Test()
		{
			return this.Content("test");
		}

		public ActionResult Vote(NewVote vote)
		{
			bool hasError = false;
			if (this.ModelState.IsValid)
			{
				string ipStr = this.Request.ServerVariables[BaseController.IpKey];

				Ip dbIp = this.Db.Ips.FirstOrDefault(ip => ip.Value == ipStr);

				if (dbIp == null)
				{
					dbIp = new Ip
					{
						Value = ipStr,
					};

					this.Db.Ips.Add(dbIp);
					this.Db.SaveChanges();
				}

				Vote dbVote = this.Mapper.Map<Vote>(vote);

				if (dbIp.RemainingVotePoints >= dbVote.VotePoints)
				{
					dbIp.RemainingVotePoints -= dbVote.VotePoints;

					dbVote.IpId = dbIp.Id;
					this.Db.Votes.Add(dbVote);
					this.Db.SaveChanges();
				}
				else
				{
					hasError = true;
				}

			}

			int totalVotes = this.Db.Ideas.First(idea => idea.Id == vote.IdeaId).Votes.DefaultIfEmpty()
				.Sum(v => v == null ? 0 : vote.VotePoints);


			return this.Content(totalVotes.ToString());
			//return this.Json(new
			//{
			//	TotalVotes = totalVotes,
			//	HasError = hasError
			//});
		}
	}
}