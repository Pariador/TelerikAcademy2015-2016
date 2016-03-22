namespace MvcTemplate.Web.InputModels
{
	using System.ComponentModel.DataAnnotations;
	using Data.Models;
	using Infrastructure.Mapping;

	public class NewIdea : IMapTo<Idea>
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string Content { get; set; }
	}
}