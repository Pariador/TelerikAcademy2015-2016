namespace MvcTemplate.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using Common.Models;

	public class Comment : BaseModel<int>
	{
		public int IdeaId { get; set; }

		public virtual Idea Idea { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		public string AuthorId { get; set; }
			
		public virtual User Author { get; set; }

		public int IpId { get; set; }

		public virtual Ip Ip { get; set; } 
	}
}