namespace MvcTemplate.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    using MvcTemplate.Data.Models;

	using Models;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

		public virtual IDbSet<Ip> Ips { get; set; }

		public virtual IDbSet<Idea> Ideas { get; set; }

		public virtual IDbSet<Comment> Comment { get; set; }

		public virtual IDbSet<Vote> Votes { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Idea>()
				.HasRequired(user => user.Ip)
				.WithMany()
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Idea>()
				.HasOptional(user => user.Author)
				.WithMany(author => author.Ideas)
				.WillCascadeOnDelete(false);

			base.OnModelCreating(modelBuilder);
		}

		private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
