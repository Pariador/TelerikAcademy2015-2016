namespace Teleimot.Data.Entity
{
	using System.Data.Entity;
	using System.Data.Entity.ModelConfiguration.Conventions;
	using Microsoft.AspNet.Identity.EntityFramework;

	using Models;

	public class TeleimotDb : IdentityDbContext<User>
	{
		public TeleimotDb()
			: base("Teleimot")
		{
			;
		}

		public static TeleimotDb Create()
		{
			return new TeleimotDb();
		}

		public virtual IDbSet<Estate> Estates { get; set; }

		public virtual IDbSet<Comment> Comments { get; set; }

		public virtual IDbSet<UserRating> UserRatings { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			base.OnModelCreating(modelBuilder);
		}
	}
}