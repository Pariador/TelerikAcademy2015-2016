using System.Linq;
using MvcTemplate.Data.Models;

namespace MvcTemplate.Services.Data
{
	public interface IIpServices
	{
		IQueryable<Ip> All();

		void Add(Ip ip);
	}
}