namespace Exam.Services
{
	using System.Linq;
	using System.Collections.Generic;

	using Data;
	using Data.Models;
	using Data.Repositories;

    public class PlaylistsService
    {
		private IRepository<Playlist> playlists;

		private IRepository<Rating> ratings;

		private IRepository<Video> videos;

		public PlaylistsService()
		{
			var db = new AppDbContext();
			this.playlists = new GenericRepository<Playlist>(db);
			this.ratings = new GenericRepository<Rating>(db);
			this.videos = new GenericRepository<Video>(db);
		}

	    public Playlist GetById(int id)
	    {
		    return this.playlists.GetById(id);
	    }

	    public IQueryable<Playlist> GetTop10()
	    {
		    return this.playlists.All()
				.OrderByDescending(playlist => playlist.Ratings.Average(rating => rating.Value))
				.Take(10);
	    }

		public void RemoveById(int id)
		{
			Playlist playlist = this.playlists.GetById(id);

			foreach (var rating in playlist.Ratings.ToArray())
			{
				this.ratings.Delete(rating);
			}

			foreach (var video in playlist.Videos.ToArray())
			{
				this.videos.Delete(video);
			}

			this.ratings.SaveChanges();

			this.playlists.Delete(playlist);
			this.playlists.SaveChanges();
		}

	    public void Add(Playlist playlist)
	    {
			this.playlists.Add(playlist);
			this.playlists.SaveChanges();
	    }
    }
}