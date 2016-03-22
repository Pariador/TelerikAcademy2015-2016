using System;
using Exam.Common;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Exam.Web
{
	using System.Linq;
	using System.Data.Entity;
	using System.Web;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.Owin;

	using Exam.Data;
	using Data.Models;
	using Data.Migrations;

	public static class DataConfig
	{
		public static void Init()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());

			using (var db = new AppDbContext())
			{
				DataConfig.Seed(db);

				try
				{
					db.SaveChanges();
				}
				catch (System.Data.Entity.Validation.DbEntityValidationException ex)
				{
					throw ex;
				}

				db.Users.ToArray();
			}
		}

		private static void Seed(AppDbContext db)
		{
			string[] roles = { "Administrator" };

			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
			for (int i = 0; i < roles.Length; i++)
			{
				if (roleManager.RoleExists(roles[i]) == false)
				{
					roleManager.Create(new IdentityRole(roles[i]));
				}
			}

			string adminEmail = "admin@site.com";

			var userManager = new UserManager<User>(new UserStore<User>(db));
			var hasher = new PasswordHasher();
			if (!db.Users.Any(u => u.UserName == adminEmail))
			{
				var user = new User
				{
					UserName = adminEmail,
					Email = adminEmail,
					PasswordHash = hasher.HashPassword("admin"),
					FirstName = "admin",
					LastName = "admin",
					AvatarUrl = ValidationConstants.DefaultAvatarUrl
				};

				userManager.Create(user);
				userManager.AddToRole(user.Id, roles[0]);
			}

			if (db.Playlists.Any())
			{
				return;
			}

			User[] users = new User[5];
			for (int i = 0; i < users.Length; i++)
			{
				string email = $"user{i}@site.com";

				users[i] = new User
				{
					UserName = email,
					Email = email,
					PasswordHash = hasher.HashPassword("user" + i),
					FirstName = "user" + i,
					LastName = "user" + i,
					AvatarUrl = ValidationConstants.DefaultAvatarUrl
				};

				userManager.Create(users[i]);
			}

			Category[] categories = new Category[30];
			for (int i = 0; i < categories.Length; i++)
			{
				categories[i] = new Category
				{
					Name = RandomGenerator.GetString(10, ValidationConstants.MaxCategoryNameLength),
				};

				db.Categories.Add(categories[i]);
			}


			Playlist[] playlits = new Playlist[10];
			for (int i = 0; i < playlits.Length; i++)
			{
				User creator = RandomGenerator.GetFromList(users.ToList());
				Category category = RandomGenerator.GetFromList(categories.ToList());

				playlits[i] = new Playlist
				{
					Title = RandomGenerator.GetString(20),
					Description = RandomGenerator.GetString(50),
					CreatorId = creator.Id,
					Creator = creator,
					CreatedOn = DateTime.Now,
					CategoryId = category.Id,
					Category = category
				};

				db.Playlists.Add(playlits[i]);

				//http://www.youtube.com/embed/XGSy3_Czz8k?autoplay=1
				string[] urls = { "https://www.youtube.com/watch?v=MkaEtV8VQ9E", "https://www.youtube.com/watch?v=jxcij0mssc8", "https://www.youtube.com/watch?v=j-KWgP_teoc" };

				Video[] videos = new Video[RandomGenerator.GetInt(1, 6)];

				for (int j = 0; j < videos.Length; j++)
				{
					videos[j] = new Video
					{
						Url = urls[j % urls.Length],
						PlaylistId = playlits[i].Id,
						Playlist = playlits[i]
					};

					db.Videos.Add(videos[j]);
				}

				Rating[] ratings = new Rating[RandomGenerator.GetInt(1, 10)];
				for (int j = 0; j < ratings.Length; j++)
				{
					User user = RandomGenerator.GetFromList(users.ToList());

					ratings[j] = new Rating
					{
						Value = RandomGenerator.GetInt(ValidationConstants.MinRatingValue, ValidationConstants.MaxRatingValue),
						UserId = user.Id,
						User = user,
						PlaylistId = playlits[i].Id,
						Playlist = playlits[i]
					};

					db.Ratings.Add(ratings[j]);
				}
			}
		}
	}
}