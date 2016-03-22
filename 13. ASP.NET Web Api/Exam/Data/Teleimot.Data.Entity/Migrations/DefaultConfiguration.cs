namespace Teleimot.Data.Entity.Migrations
{
    using System.Data.Entity.Migrations;

	using Data.Models;

    public sealed class DefaultConfiguration : DbMigrationsConfiguration<TeleimotDb>
    {
		public DefaultConfiguration()
		{
			this.AutomaticMigrationsEnabled = true;
			this.AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(TeleimotDb context)
		{
			//Estate estate = new Estate
			//{
			//	 Title = "TESTING", Description = "SEEEEEEEEEEEEEEEEEEED", ConstructionYear = 3443, Type = Common.Data.EstateType.Storehouse, RentingPrice = 2343
			//};

			//context.Estates.Add(estate);

			//Comment com = new Comment
			//{
			//	 Content = "adadasdasasd", EstateId = 2, UserId = "735fb30d-db7f-4668-b2af-e297ea8eb372"
			//};

			//context.Comments.Add(com);
		}
    }
}