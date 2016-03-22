namespace MvcTemplate.Web.ViewModels.Home
{
	using System.Collections.Generic;
	using Ideas;
	using InputModels;

	public class HomeViewModel
	{
		public HomeViewModel()
		{
			this.CurrentPage = 1;
		}

		public int CurrentPage { get; set; }

		//public int PageCount { get; set; }

		public OrederByOptions OrderBy { get; set; }

		public string Filter { get; set ;}

		public IEnumerable<IdeaViewModel> Ideas { get; set; }
	}
}