namespace InheritanceAndPolymorphism
{
    using System;

    using Courses;

    public static class CoursesExamples
    {
        internal static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases", "Svetlin Nakov", "Enerprise");
            Console.WriteLine("Without students.");
            Console.WriteLine(localCourse);

            localCourse.AddStudents("Peter", "Maria", "Milena", "Todor");
            Console.WriteLine("With students.");
            Console.WriteLine(localCourse);

            const string CourseName = "PHP and WordPress Development";
            string[] students = { "Thomas", "Ani", "Steve" };
            OffsiteCourse offsiteCourse = new OffsiteCourse(CourseName, "Mario Peshev", "London", students);
            Console.WriteLine(offsiteCourse);
        }
    }
}
