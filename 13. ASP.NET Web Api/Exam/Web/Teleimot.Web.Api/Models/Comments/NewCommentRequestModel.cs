namespace Teleimot.Web.Api.Models.Comments
{
	public class NewCommentRequestModel
	{
		public int RealEstateId { get; set; }

		public string Content { get; set; }
	}
}