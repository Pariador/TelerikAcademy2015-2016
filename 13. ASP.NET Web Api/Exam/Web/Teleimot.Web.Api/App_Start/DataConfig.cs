namespace Teleimot.Web.Api
{
	using System.Data.Entity;

	using Data.Entity;
	using Data.Entity.Migrations;

	public static class DataConfig
	{
		public static void Configure()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeleimotDb, DefaultConfiguration>());
		}
	}
}