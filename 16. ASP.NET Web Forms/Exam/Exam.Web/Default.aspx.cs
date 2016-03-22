namespace Exam.Web
{
	using System;
	using System.Linq;
	using System.Web.UI;

	using Exam.Services;

	public partial class _Default : Page
	{
		private PlaylistsService playlistsService;

		public _Default()
		{
			this.playlistsService = new PlaylistsService();
		}

		protected void Page_Load(object sender, EventArgs args)
		{
			//TODO: Link to category sort

			this.Playlists.DataSource = this.playlistsService.GetTop10()
				.ToArray();

			this.DataBind();
		}
	}
}