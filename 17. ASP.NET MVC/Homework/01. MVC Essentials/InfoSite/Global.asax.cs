namespace InfoSite
{
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Optimization;
	using System.Web.Routing;
	
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			DataConfig.Init(this.Server.MapPath("~/App_Data"));
		}
	}
}