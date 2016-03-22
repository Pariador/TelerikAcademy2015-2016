namespace Exam.Web.Playlists
{
	using System;
	using System.Linq;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using Microsoft.AspNet.Identity;


	using Data.Models;

	using Services;

	public partial class Details : Page
	{
		public Details()
		{
			this.PlaylistsService = new PlaylistsService();
			this.VideosService = new VideosService();
		}

		public VideosService VideosService { get; set; }

		public PlaylistsService PlaylistsService { get; set; }

		public bool CreatorLoggedIn { get; set; }

		public int CurrentId { get; set; }

		protected void Page_Load(object sender, EventArgs args)
		{
			int id = 0;
			try
			{
				id = int.Parse(this.Request.QueryString["id"]);
				this.CurrentId = id;
			}
			catch (Exception)
			{
				this.Response.Redirect("/");
			}

			Playlist playlist = this.PlaylistsService.GetById(id);
			this.title.InnerText = playlist.Title;
			this.Description.InnerText = playlist.Description;
			this.Category.Text = playlist.Category.Name;
			this.Creator.Text = playlist.Creator.FullName();
			this.CreatedOn.Text = playlist.CreatedOn.ToString();
			this.Rating.Text = playlist.AvgRating().ToString();

			this.Videos.DataSource = playlist.Videos;
			this.DataBind();

			this.CreatorLoggedIn = false;

			if (this.User != null)
			{
				string userId = this.User.Identity.GetUserId();

				if (playlist.Creator.Id == userId)
				{
					this.CreatorLoggedIn = true;
				}
			}
		}

		public void DeleteVideo(object sender, EventArgs args)
		{
			Button button = sender as Button;

			int id = int.Parse(button.CommandArgument);

			this.VideosService.RemoveById(id);

			this.Response.Redirect("/Playlists/Details?id=" + this.CurrentId);
		}
	}
}