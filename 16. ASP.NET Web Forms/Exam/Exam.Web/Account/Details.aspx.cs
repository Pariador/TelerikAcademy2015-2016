namespace Exam.Web.Account
{
	using System;
	using System.Linq;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	using Microsoft.AspNet.Identity;

	using Services;
	using Data.Models;

	public partial class Details : Page
	{
		private UsersService usersService;

		private PlaylistsService playlistsService;

		private User user;

		public Details()
		{
			this.usersService = new UsersService();
			this.playlistsService = new PlaylistsService();
		}

		protected void Page_Load(object sender, EventArgs args)
		{
			this.Error.Text = string.Empty;

			string userId = this.User.Identity.GetUserId();
			User user = this.usersService.GetById(userId);
			this.user = user;

			this.Email.InnerText = user.Email;
			this.Avatar.ImageUrl = user.AvatarUrl;
			this.FirstName.Text = user.FirstName;
			this.LastName.Text = user.LastName;
			this.FacebookUrl.HRef = user.FacebookUrl;
			this.YoutubeUrl.HRef = user.YoutubeUrl;

			this.Playlists.DataSource = user.Playlists.ToArray();

			this.DataBind();
		}

		public void DeletePlaylist(object sender, EventArgs args)
		{
			Button button = sender as Button;

			int id = int.Parse(button.CommandArgument);
			
			this.playlistsService.RemoveById(id);

			this.Response.Redirect("/Account/Details");
		}

		public void ChangeFirstName(object sender, EventArgs args)
		{
			if (this.NewFirstName.Text == string.Empty)
			{
				this.Error.Text = "First Name can't be empty.";
				return;
			}

			this.user.FirstName = this.NewFirstName.Text;
			this.usersService.Update(this.user);

			this.NewFirstName.Text = string.Empty;
			this.Page_Load(sender, args);
		}

		public void ChangeLastName(object sender, EventArgs args)
		{
			if (this.NewLastName.Text == string.Empty)
			{
				this.Error.Text = "Last Name can't be empty.";
				return;
			}

			this.user.LastName = this.NewLastName.Text;
			this.usersService.Update(this.user);

			this.NewLastName.Text = string.Empty;
			this.Page_Load(sender, args);
		}

		public void ChangeFacebookUrl(object sender, EventArgs args)
		{
			if (this.NewFacebookUrl.Text == string.Empty)
			{
				this.Error.Text = "Facebook Url can't be empty.";
				return;
			}

			this.user.FacebookUrl = this.NewFacebookUrl.Text;
			this.usersService.Update(this.user);

			this.NewFacebookUrl.Text = string.Empty;
			this.Page_Load(sender, args);
		}

		public void ChangeYoutubeUrl(object sender, EventArgs args)
		{
			if (this.NewYoutubeUrl.Text == string.Empty)
			{
				this.Error.Text = "Youtube Url can't be empty.";
				return;
			}

			this.user.YoutubeUrl = this.NewYoutubeUrl.Text;
			this.usersService.Update(this.user);

			this.NewYoutubeUrl.Text = string.Empty;
			this.Page_Load(sender, args);
		}

		public void ChangeAvatarUrl(object sender, EventArgs args)
		{
			if (this.NewAvatarUrl.Text == string.Empty)
			{
				this.Error.Text = "Avatar can't be empty.";
				return;
			}

			this.user.AvatarUrl = this.NewAvatarUrl.Text;
			this.usersService.Update(this.user);

			this.NewAvatarUrl.Text = string.Empty;
			this.Page_Load(sender, args);
		}
	}
}