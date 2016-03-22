namespace Students
{
    using System;
    using System.Linq;
    using ObjectLibrary;
    using System.Collections.Generic;

    internal static class UsingStudens
    {
        public static void FirstBeforeLast(IEnumerable<Student> students)
        {
            //var result = students.Where(st => st.FirstName.CompareTo(st.LastName) == -1);
            
            var result = from st in students
                         where st.FirstName.CompareTo(st.LastName) == -1
                         select st;

            Console.WriteLine("First before last:");
            foreach (var student in result)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
        public static void Aged18to24(IEnumerable<Student> students)
        {
            //var studentNames = students.Where(st => st.Age >= 18 && st.Age <= 24)
            //    .Select(st => new { FirstName = st.FirstName, LastName = st.LastName });
            var studentNames = from st in students
                               where st.Age >= 18 && st.Age <= 24
                               select new { FirstName = st.FirstName, LastName = st.LastName };

            Console.WriteLine("\nStudents aged 18 to 24:");
            foreach (var name in studentNames)
            {
                Console.WriteLine("{0} {1}", name.FirstName, name.LastName);
            }
        }
        public static void SortStudents(IEnumerable<Student> students)
        {
            var sortedStudetns = students.OrderBy(st => st.FirstName);

            Console.WriteLine("\nStudents sorted by first name.");
            foreach (var student in sortedStudetns)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
        public static void SortStudentsDes(IEnumerable<Student> students)
        {
            //var sortedStudents = students.OrderByDescending(st => st.FirstName)
            //                                .ThenByDescending(st => st.LastName);
            var sortedStudents = from st in students
                                 orderby st.FirstName descending,
                                 st.LastName descending
                                 select st;

            Console.WriteLine("\nStudents sorted by first and last name:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
        public static void AbvStudents(IEnumerable<Student> students)
        {
            //var result = from st in students
            //             where st.Email.Contains("abv.bg")
            //             select st;

            var result = students.Where(st => st.Email.Contains("abv.bg"));

            Console.WriteLine("\nStudents with emains at abv.bg.");
            foreach (var student in result)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
        public static void WithSofiaTel(IEnumerable<Student> students)
        {
            //var result = from st in students
            //             where st.Tel != null && st.Tel.Length >= 2 && (st.Tel[0] == '0' && st.Tel[1] == '2')
            //             select st;

            var result = students.Where(st => st.Tel != null && st.Tel.Length >= 2 && (st.Tel[0] == '0' && st.Tel[1] == '2'));

            Console.WriteLine("\nStudents with phones in Sofia.");
            foreach (var student in result)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
        public static void WithExcellentGrade(IEnumerable<Student> students)
        {
            var result = students.Where(st => st.Marks.Values.Any(grd => grd >= 5.50))
                                 .Select(st => new { FullName = String.Format("{0} {1}", st.FirstName, st.LastName), Marks = st.Marks });

            Console.WriteLine("\nStudents with at least one excellent grade:");
            foreach (var student in result)
            {
                Console.WriteLine("{0}:", student.FullName);
                foreach (var mark in student.Marks)
                {
                    Console.WriteLine("{0}: {1: 0.00}", mark.Key, mark.Value);
                }
                Console.WriteLine();
            }
        }
        public static void With2WeakGrades(IEnumerable<Student> students)
        {
            var result = students.Where(st => st.Marks.Values.Count(grd => grd < 3) >= 2)
                                 .Select(st => new  {FullName = String.Format("{0} {1}", st.FirstName, st.LastName), Marks = st.Marks });

            Console.WriteLine("\nStudents with two weak grades:");
            foreach (var student in result)
            {
                Console.WriteLine("{0}:", student.FullName);
                foreach (var mark in student.Marks)
                {
                    Console.WriteLine("{0}: {1: 0.00}", mark.Key, mark.Value);
                }
                Console.WriteLine();
            }
        }
        public static void MarksOf06(IEnumerable<Student> students)
        {
            var result = students.Where(st => st.FacultyNum != null && st.FacultyNum[4] == '0' && st.FacultyNum[5] == '6')
                                 .Select(st => st.Marks);

            Console.WriteLine("\nMarks of 2006:");
            foreach (var marks in result)
            {
                foreach (var mark in marks)
                {
                    Console.WriteLine("{0}: {1: 0.00}", mark.Key, mark.Value);
                }
            }
        }
        public static void AllStudentsInGroup(IEnumerable<Student> students, Group group)
        {
            var result = students.Where(st => st.StudentGroup != null && st.StudentGroup.DepartmentName == group.DepartmentName);

            foreach (var student in result)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
        public static void GroupedStudetns(IEnumerable<Student> students)
        {
            //var groups = from st in students
            //             group st by st.StudentGroup into aGroup
            //             select aGroup;

            var groups = students.GroupBy(st => st.StudentGroup);

            Console.WriteLine();
            foreach (var group in groups)
            {
                Console.WriteLine("Group: {0}", group.Key.DepartmentName);
                foreach (var student in group)
                {
                    Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
                }
                Console.WriteLine();
            }
        }
        public static void DevisableBy7and3(IEnumerable<int> numbers)
        {
            //var result = from num in numbers
            //             where num % 3 == 0 && num % 7 == 0
            //             select num;
            //foreach (var num in result)
            //{
            //    Console.WriteLine(num);
            //}
            Console.WriteLine("\nNumbers devisible by 7 and 3:");
            foreach (var num in numbers.Where(n => n % 3 == 0 && n % 7 == 0))
	        {
                Console.WriteLine(num);
	        }     
        }
        public static void LongestString(IEnumerable<string> strings)
        {
            string longestStr = strings.FirstOrDefault(str => str.Length == strings.Max(maxStr => maxStr.Length));
            Console.WriteLine("\nThe longest string: {0}", longestStr);
        }

        static void Main()
        {
            int[] numbers = new int[100];
            for (int i = 0; i < 100; i++)
            {
                numbers[i] = i + 1;
            }

            string[] strings = { "1", "22", "333", "4444", "55555", "666666", "7777777", "88888888" };

            var maths = new Group("Mathematics");
            var books = new Group("Book Club");
            var physics = new Group("Physics");


            var studentList = new List<Student>();
            studentList.Add(new Student("John", "Poe", new DateTime(1995, 9, 22)) { Email = "something@abv.bg", Tel = "02131231541", FacultyNum = "010106", StudentGroup = maths });
            studentList[0].Marks[Subjects.English] = 4.23;
            studentList[0].Marks[Subjects.Physics] = 2.62;
            studentList[0].Marks[Subjects.Mathematics] = 2.99;
            studentList.Add(new Student("John", "Doe", new DateTime(1996, 1, 17)) { Email = "something@mail.bg", Tel = "089613212312151", FacultyNum = "010106", StudentGroup = physics });
            studentList[1].Marks[Subjects.English] = 3.42;
            studentList[1].Marks[Subjects.Physics] = 5.87;
            studentList[1].Marks[Subjects.Mathematics] = 5.33;
            studentList.Add(new Student("Anny", "Meuser", new DateTime(1994, 3, 7)) { Email = "something@abv.bg",  StudentGroup = books });
            studentList[2].Marks[Subjects.English] = 4.23;
            studentList[2].Marks[Subjects.Physics] = 2.62;
            studentList[2].Marks[Subjects.Mathematics] = 2.30;
            studentList.Add(new Student("Ace", "Zero", new DateTime(1997, 5, 29)) { Email = "something@abv.bg", Tel = "025234634345", StudentGroup = maths });
            studentList[3].Marks[Subjects.English] = 4.37;
            studentList[3].Marks[Subjects.Physics] = 5.50;
            studentList[3].Marks[Subjects.Mathematics] = 4.56;
            studentList.Add(new Student("Melody", "Forst", new DateTime(1989, 11, 2)) { Email = "something@gmail.com", StudentGroup = physics });
            studentList[4].Marks[Subjects.English] = 3.86;
            studentList[4].Marks[Subjects.Physics] = 5.84;
            studentList[4].Marks[Subjects.Mathematics] = 4.54;
            studentList.Add(new Student("Rubin", "Mccants", new DateTime(1991, 7, 12)) { Email = "something@gmail.com", FacultyNum = "010106", StudentGroup = maths });
            studentList[5].Marks[Subjects.English] = 5.05;
            studentList[5].Marks[Subjects.Physics] = 5.57;
            studentList[5].Marks[Subjects.Mathematics] = 4.43;

            FirstBeforeLast(studentList);
            Aged18to24(studentList);
            SortStudents(studentList);
            SortStudentsDes(studentList);
            AbvStudents(studentList);
            WithSofiaTel(studentList);
            WithExcellentGrade(studentList);
            With2WeakGrades(studentList);
            MarksOf06(studentList);
            AllStudentsInGroup(studentList, maths);
            GroupedStudetns(studentList);
            DevisableBy7and3(numbers);
            LongestString(strings);
        }
    }
}