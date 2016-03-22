namespace Teleimot.Web.Api
{
	using System.Web;
	using System.Web.Http;

	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			DataConfig.Configure();
			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
	}
}