namespace Teleimot.Data
{
	using System.Data.Entity;

	using Entity;

	public class TeleimotRepository<T> : EfGenericRepository<T> where T : class
	{
		private TeleimotRepository(DbContext context)
			: base(context)
		{
			;
		}

		public TeleimotRepository()
			: base(new TeleimotDb())
		{
			;
		}

		public TeleimotRepository<TOther> CreateWithSameContext<TOther>() where TOther : class
		{
			return new TeleimotRepository<TOther>(this.Context);
		}
	}
}