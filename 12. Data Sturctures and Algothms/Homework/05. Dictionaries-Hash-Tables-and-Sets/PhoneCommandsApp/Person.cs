namespace PhoneCommandsApp
{
	public class Person
	{
		public Person(string name, string town, string phone)
		{
			this.Name = name;
			this.Town = town;
			this.Phone = phone;
		}

		public string Name { get; private set; }

		public string Town { get; private set; }

		public string Phone { get; private set; }

		public override string ToString()
		{
			return $"{nameof(this.Name)}: {this.Name}, {nameof(this.Town)}: {this.Town}, {nameof(this.Phone)}: {this.Phone}";
		}
	}
}