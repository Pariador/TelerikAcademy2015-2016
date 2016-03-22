namespace SocialNetwork.Data
{
    using System.Data.Entity;

    using SocialNetwork.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext()
            : base("SocialNetwork")
        {
            ;
        }

        public virtual IDbSet<UserProfile> UserProfiles { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}