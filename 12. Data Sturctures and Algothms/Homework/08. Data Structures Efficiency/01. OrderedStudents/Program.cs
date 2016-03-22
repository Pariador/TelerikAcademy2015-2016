namespace OrderedStudents
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Collections.Generic;

	public static class Program
	{
		public const string StudentsFilePath = "students.txt";

		public static List<Student> ReadStudents()
		{
			using (var reader = new StreamReader(Program.StudentsFilePath))
			{
				var students = new List<Student>();

				while (true)
				{
					string line = reader.ReadLine();
					if (line == null)
					{
						break;
					}

					string[] studentData = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
						.Select(str => str.Trim())
						.Where(str => str != string.Empty)
						.ToArray();

					if (studentData.Length != 3)
					{ 
						break;
					}

					Student student = new Student
					{
						FirstName = studentData[0],
						LastName = studentData[1],
						Course = studentData[2]
					};

					students.Add(student);
				}

				return students;
			}

		}

		public static void Main()
		{
			var studentGroups = Program.ReadStudents()
				.GroupBy(gr => gr.Course);

			var sortedGroups = new SortedDictionary<string, IEnumerable<Student>>();

			foreach (var group in studentGroups)
			{
				var students = group.OrderBy(st => st.LastName)
					.ThenBy(st => st.FirstName);

				sortedGroups.Add(group.Key, students);
			}

			foreach (var group in sortedGroups)
			{
				Console.WriteLine("Students in group {0}:", group.Key);

				foreach (var student in group.Value)
				{
					Console.WriteLine("\t" + student);
				}
			}
		}
	}
}