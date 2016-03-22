namespace Exam.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Exam.Common;

	public class Category
	{
		private ICollection<Playlist> playlists;

		public Category()
		{
			this.playlists = new HashSet<Playlist>();
		}

		public int Id { get; set; }

		[Required]
		[Index(IsUnique = true)]
		[MaxLength(ValidationConstants.MaxCategoryNameLength)]
		public string Name { get; set; }

		public virtual ICollection<Playlist> Playlists
		{
			get
			{
				return this.playlists;
			}

			set
			{
				this.playlists = value;
			}
		}
	}
}