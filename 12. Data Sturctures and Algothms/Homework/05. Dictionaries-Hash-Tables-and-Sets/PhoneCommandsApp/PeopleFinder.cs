namespace PhoneCommandsApp
{
	using System.Collections.Generic;

	public class PeopleFinder
	{
		public PeopleFinder(IEnumerable<Person> people)
		{
			this.SetSearchingCollections(people);
		}

		private Dictionary<string, List<Person>> ByName { get; set; }

		private Dictionary<NameTownPair, List<Person>> ByNameAndTown { get; set; }

		public void SetSearchingCollections(IEnumerable<Person> people)
		{
			this.ByName = people.GroupInDictionary(p => p.Name);
			this.ByNameAndTown = people.GroupInDictionary(p => new NameTownPair(p.Name, p.Town));
		}

		public List<Person> Find(string name)
		{
			if (this.ByName.ContainsKey(name))
			{
				return this.ByName[name];
			}

			return new List<Person>();
		}

		public List<Person> Find(string name, string town)
		{
			var key = new NameTownPair(name, town);

			if (this.ByNameAndTown.ContainsKey(key))
            {
	            return this.ByNameAndTown[key];
			}

			return new List<Person>();
		}

		private struct NameTownPair
		{
			public readonly string Town;

			public readonly string Name;

			public NameTownPair(string name, string town)
			{
				this.Town = town;
				this.Name = name;
			}

			public override int GetHashCode()
			{
				return (this.Name + this.Town).GetHashCode();
			}

			public bool Equals(NameTownPair other)
			{
				return this.Name == other.Name && this.Town == other.Town;
			}

			public override bool Equals(object obj)
			{
				if (obj is NameTownPair)
				{
					return this.Equals((NameTownPair)obj);
				}

				return false;
			}
		}
	}
}