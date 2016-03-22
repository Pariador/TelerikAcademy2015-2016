namespace PhoneCommandsApp
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;

	/// <summary>
	/// 06. (*) A text file phones.txt holds information about people, their town and phone number:
	/// 
	/// Mimi Shmatkata          | Plovdiv  | 0888 12 34 56
	/// Kireto                  | Varna    | 052 23 45 67
	/// Daniela Ivanova Petrova | Karnobat | 0899 999 888
	/// Bat Gancho              | Sofia    | 02 946 946 946
	/// Duplicates can occur in people names, towns and phone numbers. Write a program to read the phones file
	/// and execute a sequence of commands given in the file commands.txt:
	/// 
	/// find(name) – display all matching records by given name (first, middle, last or nickname)
	/// find(name, town) – display all matching records by given name and town 
	/// </summary>
	public static class PhoneCommands
	{
		public const string PhonesPath = "phones.txt";

		public const string CommandsPath = "commands.txt";

		public static List<Person> GetPeople()
		{
			using (var reader = new StreamReader(PhoneCommands.PhonesPath))
			{
				List<Person> people = new List<Person>();

				while (true)
				{
					string line = reader.ReadLine();
					if (line == null)
					{
						break;
					}
					
					string[] personData = line.Split('|')
							.Select(str => str.Trim())
							.ToArray();

					Person person = new Person(personData[0], personData[1], personData[2]);
					people.Add(person);
				}

				return people;
			}
		}

		public static void ExecFindCommands(PeopleFinder finder)
		{
			Regex matchCommand = new Regex("^find\\((\\S+)(?:, (\\S+))?\\)$");

			using (var reader = new StreamReader(PhoneCommands.CommandsPath))
			{
				while (true)
				{
					string line = reader.ReadLine();
					if (line == null)
					{
						break;
					}

					Match match = matchCommand.Match(line);
					if (!match.Success)
					{
						continue;
					}

					string command = match.Value;
					string person = match.Groups[1].Value;
					string town = match.Groups[2].Value;

					List<Person> result;
					if (town == string.Empty)
					{
						result = finder.Find(person);
					}
					else
					{
						result = finder.Find(person, town);
					}

					PhoneCommands.PrintCommandResult(command, result);
                }
			}
		}

		public static void PrintCommandResult(string command, List<Person> result)
		{
			Console.WriteLine("{0}: ", command);
			foreach (var person in result)
			{
				Console.WriteLine(person);
			}
			Console.WriteLine();
		}

		public static void Main()
		{
			var people = PhoneCommands.GetPeople();

			var finder = new PeopleFinder(people);

			PhoneCommands.ExecFindCommands(finder);
        }
	}
}