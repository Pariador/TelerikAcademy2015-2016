namespace MvcTemplate.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using Common.Models;

	public class Idea : BaseModel<int>
	{
		private ICollection<Vote> votes;

		private ICollection<Comment> comments;

		public Idea()
		{
			this.votes = new HashSet<Vote>();
			this.comments = new HashSet<Comment>();
		}

		[Required]
		public string Title { get; set; }

		[Required]
		public string Content { get; set; }

		public string AuthorId { get; set; }

		public virtual User Author { get; set; }

		public int IpId { get; set; }

		public virtual Ip Ip { get; set; }

		public virtual ICollection<Vote> Votes
		{
			get
			{
				return this.votes;
			}

			set
			{
				this.votes = value;
			}
		}

		public virtual ICollection<Comment> Comments
		{
			get
			{
				return this.comments;
			}

			set
			{
				this.comments = value;
			}
		}
	}
}