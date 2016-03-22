namespace Teleimot.Web.Api.Models.Users
{
	public class UserInfoViewModel
	{
		public string Email { get; set; }

		public bool HasRegistered { get; set; }

		public string LoginProvider { get; set; }
	}
}