namespace MvcTemplate.Data.Models
{
	using Common.Models;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;

	public class Ip : BaseModel<int>
	{
		public Ip()
		{
			this.RemainingVotePoints = 10;
		}

		public string Value { get; set; }

		[DefaultValue(10)]
		public int RemainingVotePoints { get; set; }
	}
}