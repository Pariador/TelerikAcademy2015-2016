namespace Teleimot.Web.WCF
{
	using System;
	using System.Linq;

	using Data.Models;
	using Services;

	public class Top : ITop
	{
		public TopResponseModel Top()
		{
			var result = new UserService().TopTen().;
		}
	}
}