namespace SourceControlSystem.Api.Models.Commits
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using SourceControlSystem.Models;
    using System;

    public class CommitDetailsResponseModel : IMapFrom<Commit>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string SourceCode { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ProjectName { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Commit, CommitDetailsResponseModel>()
                .ForMember(c => c.ProjectName, opt => opt.MapFrom(c => c.SoftwareProject.Name))
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.UserName));
        }
    }
}
