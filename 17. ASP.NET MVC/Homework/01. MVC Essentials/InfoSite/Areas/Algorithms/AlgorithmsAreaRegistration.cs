namespace InfoSite.Areas.Algorithms
{
	using System.Web.Mvc;

	public class AlgorithmsAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Algorithms";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AlgorithmsDefault",
                "Algorithms/{controller}/{action}/{id}",
                new { controller = "Main", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}