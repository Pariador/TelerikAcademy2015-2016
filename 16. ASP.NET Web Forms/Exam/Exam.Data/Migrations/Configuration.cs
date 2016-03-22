namespace Exam.Data.Migrations
{
	using System;
	using System.Linq;
    using System.Data.Entity.Migrations;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;

	using Data;
	using Models;

    public sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
			this.AutomaticMigrationsEnabled = true;
			this.AutomaticMigrationDataLossAllowed = true;
        }

		protected override void Seed(AppDbContext db)
		{
			// moved to DataConfig
		}
	}
}