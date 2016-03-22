using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using System.Reflection;
using SourceControlSystem.Common.Constants;

[assembly: OwinStartup(typeof(SourceControlSystem.Api.Startup))]

namespace SourceControlSystem.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigureAuth(app);

            app
                .UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(config);
        }
    }
}
