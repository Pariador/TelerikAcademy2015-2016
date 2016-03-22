namespace Exam.Data.Models
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Playlist
	{
		private ICollection<Video> videos;

		private ICollection<Rating> ratings;

		public Playlist()
		{
			this.videos = new HashSet<Video>();
			this.ratings = new HashSet<Rating>();
		}

		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		public DateTime CreatedOn { get; set; }

		[Required]
		public string CreatorId { get; set; }

		public virtual User Creator { get; set; }

		public int CategoryId { get; set; }

		public virtual Category Category { get; set; }

		public virtual ICollection<Video> Videos
		{
			get
			{
				return this.videos;
			}

			set
			{
				this.videos = value;
			}
		}

		public virtual ICollection<Rating> Ratings
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

		public double AvgRating()
		{
			if (!this.Ratings.Any())
			{
				return 0;
			}

			return this.Ratings.Average(rating => rating.Value);
		}
	}
}