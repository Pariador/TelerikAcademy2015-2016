namespace Exam.Data.Models
{
	using System.Text.RegularExpressions;
	using System.ComponentModel.DataAnnotations;

	public class Video
	{
		public int Id { get; set; }

		[Required]
		public string Url { get; set; }

		public int PlaylistId { get; set; }

		public virtual Playlist Playlist { get; set; }

		public string GetEmbededUrl()
		{
			//http://www.youtube.com/embed/XGSy3_Czz8k?autoplay=1
			//https://www.youtube.com/watch?v=MkaEtV8VQ9
			Regex regex = new Regex(@"watch\?v=([\s\S]+)$");

			var match = regex.Match(this.Url);

			string vidId = match.Groups[1].Value;

			return $"http://www.youtube.com/embed/{vidId}";
		}
	}
}