namespace MoviesDb.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Person
	{
		private ICollection<Movie> leadingActorIn;

		private ICollection<Movie> directorOf;

		public Person()
		{
			this.leadingActorIn = new HashSet<Movie>();
			this.directorOf = new HashSet<Movie>();
		}

		public int Id { get; set; }

		[Required]
		[MaxLength(ValidationConstants.PersonNameMaxLength)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(ValidationConstants.PersonNameMaxLength)]
		public string LastName { get; set; }

		public DateTime BirthDate { get; set; }

		[InverseProperty("LeadingActor")]
		public virtual ICollection<Movie> LeadingActorIn
		{
			get
			{
				return this.leadingActorIn;
			}

			set
			{
				this.leadingActorIn = value;
			}
		}

		[InverseProperty("Director")]
		public virtual ICollection<Movie> DirectorOf
		{
			get
			{
				return this.directorOf;
			}

			set
			{
				this.directorOf = value;
			}
		}

		[NotMapped]
		public string FullName {
			get
			{
				return this.FirstName + " " + this.LastName;
			}
		}

		public override string ToString()
		{
			return this.FullName;
		}
	}
}