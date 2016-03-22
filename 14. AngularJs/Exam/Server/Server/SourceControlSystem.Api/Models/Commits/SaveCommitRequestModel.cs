namespace SourceControlSystem.Api.Models.Commits
{
    using System.ComponentModel.DataAnnotations;

    public class SaveCommitRequestModel
    {
        public int ProjectId { get; set; }
        
        [Required]
        public string SourceCode { get; set; }
    }
}
