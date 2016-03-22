namespace SourceControlSystem.Services.Common
{
    using SourceControlSystem.Common.Constants;

    public class ProjectRequest
    {
        public ProjectRequest()
        {
            this.Page = 1;
            this.PageSize = GlobalConstants.DefaultPageSize;
            this.OrderBy = "date";
            this.OrderType = "desc";
        }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; }

        public string OrderBy { get; set; }

        public string OrderType { get; set; }

        public string ByUser { get; set; }

        public bool OnlyPublic { get; set; }
    }
}
