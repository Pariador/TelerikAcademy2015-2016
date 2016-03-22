namespace MoviesDb.Data
{
	using System.Data.Entity;

	using Models;

	public class MoviesDbContext : DbContext
	{
		public MoviesDbContext()
			: base("DefaultConnection")
		{
			;
		}

		public virtual IDbSet<Movie> Movies { get; set; }

		public virtual IDbSet<Person> People { get; set; }

		public virtual IDbSet<Studio> Studios { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>()
				.HasRequired(movie => movie.LeadingActor)
				.WithMany(actor => actor.LeadingActorIn)
				.WillCascadeOnDelete(false);

			base.OnModelCreating(modelBuilder);
		}
	}
}