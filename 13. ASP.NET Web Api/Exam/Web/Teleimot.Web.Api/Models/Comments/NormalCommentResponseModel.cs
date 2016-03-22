namespace Teleimot.Web.Api.Models.Comments
{
	using System;
	using Data.Models;

	public class NormalCommentResponseModel
	{
		public string Content { get; set; }

		public string UserName { get; set; }

		public DateTime CreatedOn { get; set; }
	}
}