namespace Teleimot.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Security.Claims;
	using System.Threading.Tasks;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;

	public class User : IdentityUser
    {
		private ICollection<Estate> estates;
		private ICollection<Comment> comments;
		private ICollection<UserRating> ratings;

		public User()
			: base()
		{
			this.estates = new HashSet<Estate>();
			this.comments = new HashSet<Comment>();
			this.ratings = new HashSet<UserRating>();
		}

		public virtual ICollection<Estate> Esatates
		{
			get
			{
				return this.estates;
			}

			set
			{
				this.estates = value;
			}
		}

		public virtual ICollection<Comment> Comments
		{
			get
			{
				return this.comments;
			}

			set
			{
				this.comments = value;
			}
		}

		public virtual ICollection<UserRating> Ratings
		{
			get
			{
				return this.ratings;
			}

			set
			{
				this.ratings = value;
			}
		}

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}