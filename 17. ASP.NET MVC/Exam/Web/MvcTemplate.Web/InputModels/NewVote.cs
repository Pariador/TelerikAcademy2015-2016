using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTemplate.Web.InputModels
{
	using System.ComponentModel.DataAnnotations;
	using Data.Models;
	using Infrastructure.Mapping;

	public class NewVote : IMapTo<Vote>
	{
		[Range(1, 3)]
		public int VotePoints { get; set; }

		public int IdeaId { get; set;}
	}
}