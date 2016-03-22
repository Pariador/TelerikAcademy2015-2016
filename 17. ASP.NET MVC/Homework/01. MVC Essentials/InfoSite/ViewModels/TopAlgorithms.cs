namespace InfoSite.ViewModels
{
	using System.Collections.Generic;

	using Data;
	using Data.Models;

	public class TopAlgorithms
	{
		public TopAlgorithms(IEnumerable<Algorithm> algorithms)
		{
			this.Algorithms = algorithms;
		}

		public TopAlgorithms()
			: this(new Algorithm[0])
		{
			;
		}

		public string Message { get; set; }

		public IEnumerable<Algorithm> Algorithms { get; }
	}
}