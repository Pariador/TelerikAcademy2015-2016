namespace MoviesDb.Web
{
	using System.Data.Entity;

	using Data;
	using Data.Migrations;

	public static class DataConfig
	{
		public static void Init()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesDbContext, Configuration>());
		}
	}
}