namespace SourceControlSystem.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SourceControlSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SourceControlSystemDbContext context)
        {
            context.Licenses.AddOrUpdate(l => l.Name,
                new License
                {
                    Name = "MIT",
                },
                new License
                {
                    Name = "Apache"
                },
                new License
                {
                    Name = "GPL"
                },
                new License
                {
                    Name = "BSD"
                },
                new License
                {
                    Name = "Mozilla Public License"
                });
            
            base.Seed(context);
        }
    }
}
