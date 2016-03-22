namespace Exam.Services
{
	using Exam.Data;
	using Exam.Data.Models;
	using Exam.Data.Repositories;

	public class VideosService
	{
		private IRepository<Video> videos;

		public VideosService()
		{
			this.videos = new GenericRepository<Video>(new AppDbContext());
		}

		public void RemoveById(int id)
		{
			Video video = this.videos.GetById(id);

			videos.Delete(video);

			videos.SaveChanges();
		}
	}
}