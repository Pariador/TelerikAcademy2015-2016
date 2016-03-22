namespace Teleimot.Web.Api.Models.Users
{
	public class UserRatingRequestModel
	{
		public string UserId { get; set; }

		public byte Value { get; set; }
	}
}