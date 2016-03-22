namespace Exam.Data
{
	using System.Data.Entity;
	using System.Data.Entity.ModelConfiguration.Conventions;
	using Microsoft.AspNet.Identity.EntityFramework;

	using Exam.Data.Models;

	public class AppDbContext : IdentityDbContext<User>, IAppDbContext
	{
		public AppDbContext()
			: base("DefaultConnection")
		{
		}

		public static AppDbContext Create()
		{
			return new AppDbContext();
		}

		public virtual IDbSet<Category> Categories { get; set; }

		public virtual IDbSet<Rating> Ratings { get; set; }

		public virtual IDbSet<Playlist> Playlists { get; set; }

		public virtual IDbSet<Video> Videos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			base.OnModelCreating(modelBuilder);
		}
	}
}