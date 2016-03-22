using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;

using Exam.Services;
using Exam.Data.Models;

namespace Exam.Web.Playlists
{
	public partial class Create : System.Web.UI.Page
	{
		public Create()
		{
			this.CategoryService = new CategoryService();
			this.PlaylistsService = new PlaylistsService();
		}

		public CategoryService CategoryService { get; set; }

		public PlaylistsService PlaylistsService { get; set; }

		protected void Page_Load(object sender, EventArgs args)
		{
			this.Categories.DataSource = this.CategoryService.All().ToArray();

			this.DataBind();
		}

		public void Submit(object sender, EventArgs args)
		{
			Playlist playlist = new Playlist
			{
				Title = this.Title.Text,
				Description = this.Description.Text,
				CreatedOn = DateTime.Now,
				CreatorId = this.User.Identity.GetUserId(),
				CategoryId = int.Parse(this.Categories.SelectedItem.Value),
			};

			var videos = this.VideoUrls.Text.Split(new[] { ", " }, StringSplitOptions.None)
				.Select(url => new Video
				{
					Url = url,
					PlaylistId = playlist.Id
				});

			foreach (var video in videos)
			{
				playlist.Videos.Add(video);
			}

			this.PlaylistsService.Add(playlist);

			this.Response.Redirect("/Playlists/Details?id=" + playlist.Id);
		} 
	}
}