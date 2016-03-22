namespace MvcTemplate.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using Common.Models;

	public class Vote : BaseModel<int>
	{
		[Range(1, 3)]
		public int VotePoints { get; set; }

		public int IpId { get; set; }

		public virtual Ip Ip { get; set; }

		public int IdeaId { get; set; }

		public virtual Idea Idea { get; set; }
	}
}