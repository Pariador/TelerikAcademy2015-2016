namespace Teleimot.Web.Api.Models.Users
{
	using System.ComponentModel.DataAnnotations;

	public class RegisterExternalBindingModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}