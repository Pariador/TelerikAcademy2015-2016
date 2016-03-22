namespace Exam.Data.Models
{
	using System.Collections.Generic;
	using System.Security.Claims;
	using System.Threading.Tasks;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;

	public class User : IdentityUser
	{
		private ICollection<Playlist> playlists;

		public User()
		{
			this.playlists = new HashSet<Playlist>();
		}

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string AvatarUrl { get; set; }

		public string FacebookUrl { get; set; }

		public string YoutubeUrl { get; set; }

		[InverseProperty("Creator")]
		public virtual ICollection<Playlist> Playlists { get; set; }

		public string FullName()
		{
			return this.FirstName + " " + this.LastName;
		}

		public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}

		public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
		{
			return Task.FromResult(GenerateUserIdentity(manager));
		}
	}
}