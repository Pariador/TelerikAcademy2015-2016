namespace MvcTemplate.Services.Data
{
	using MvcTemplate.Data.Common;
	using MvcTemplate.Data.Models;
	using System.Linq;
	public class IpServices : IIpServices
	{
		public IpServices(IDbRepository<Ip> ips)
		{
			this.Ips = ips;
		}

		protected IDbRepository<Ip> Ips { get; }

		public IQueryable<Ip> All()
		{
			return this.Ips.All();
		}

		public void Add(Ip ip)
		{
			this.Ips.Add(ip);
			this.Ips.Save();
		}
	}
}