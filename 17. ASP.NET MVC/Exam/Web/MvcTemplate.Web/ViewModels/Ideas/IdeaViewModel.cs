namespace MvcTemplate.Web.ViewModels.Ideas
{
	using System.Linq;
	using System.ComponentModel.DataAnnotations;
	using AutoMapper;
	using Data.Models;
	using Infrastructure.Mapping;

	public class IdeaViewModel : IMapFrom<Idea>, IHaveCustomMappings
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Content { get; set; }

		public int VotesCount { get; set; }

		public void CreateMappings(IMapperConfiguration configuration)
		{
			//configuration.CreateMap<Idea, IdeaViewModel>()
					
		}
	}
}