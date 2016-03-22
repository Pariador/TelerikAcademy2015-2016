namespace MvcTemplate.Services.Data
{
	using MvcTemplate.Data.Common;
	using MvcTemplate.Data.Models;

	public class IdeasServices : IIdeasServices
	{
		public IdeasServices(IDbRepository<Idea> ideas)
		{
			this.Ideas = ideas;
		}

		protected IDbRepository<Idea> Ideas { get; }

		public void Add(Idea idea)
		{
			this.Ideas.Add(idea);
			this.Ideas.Save();
		}
	}
}