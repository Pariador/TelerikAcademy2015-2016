namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Mapping;
    using MvcTemplate.Services.Web;

    public abstract class BaseController : Controller
    {
		public const string IpKey = "REMOTE_ADDR";

        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}
