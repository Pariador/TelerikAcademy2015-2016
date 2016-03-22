namespace MvcTemplate.Web.Controllers
{
	using System.Linq;
	using System.Web.Mvc;

	using Data.Models;
	using Services.Data;
	using InputModels;

	public class IdeasController : BaseController
	{
		public IdeasController(IIdeasServices ideasServices, IIpServices ipServices)
		{
			this.IdeasServices = ideasServices;
			this.IpServices = ipServices;
		}

		protected IIdeasServices IdeasServices { get; }
		public IIpServices IpServices { get; set; }

		[HttpPost]
		public ActionResult Create(NewIdea idea)
		{
			if (this.ModelState.IsValid)
			{
				string ipStr = this.Request.ServerVariables[BaseController.IpKey];

				Ip dbIp = this.IpServices.All()	
					.FirstOrDefault(ip => ip.Value == ipStr);

				if (dbIp == null)
				{
					dbIp = new Ip {Value = ipStr};
					this.IpServices.Add(dbIp);
				}

				var dbIdea = this.Mapper.Map<Idea>(idea);

				dbIdea.Ip = dbIp;

				this.IdeasServices.Add(dbIdea);

				this.TempData[TempDataKeys.Success] = "Idea Added";
			}
			else
			{
				this.TempData[TempDataKeys.Error] = "Idea data is invalid";
			}

			return this.RedirectToAction("Index", "Home");
		}
	}
}