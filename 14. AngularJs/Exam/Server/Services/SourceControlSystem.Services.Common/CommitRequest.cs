namespace SourceControlSystem.Services.Common
{
    using SourceControlSystem.Common.Constants;

    public class CommitRequest
    {
        public CommitRequest()
        {
            this.Id = 0;
            this.Page = 1;
            this.PageSize = GlobalConstants.DefaultPageSize;
        }

        public int Id { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
        
        public string ByUser { get; set; }
    }
}
