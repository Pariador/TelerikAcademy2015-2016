namespace SchoolProgram
{
    using System;

    internal static class EntryPoint
    {
        internal static void Main()
        {
            School school = new School();

            school.Clases.Add(new SchoolClass("Math Class"));
            school.Clases.Add(new SchoolClass("Physics Class"));
            school.Clases.Add(new SchoolClass("Witchcraft and Wizardry Class"));

            school.Clases[0].TeachersList.Add(new Teacher("Albert Einstein"));
            school.Clases[0].TeachersList[0].Disciplines.Add(new Discipline("Theoretical Physics"));
            school.Clases[1].TeachersList.Add(new Teacher("Isaac Newton"));
            school.Clases[1].TeachersList[0].Disciplines.Add(new Discipline("Apples"));
            school.Clases[2].TeachersList.Add(new Teacher("Albus Dumbledore"));
            school.Clases[2].TeachersList[0].Disciplines.Add(new Discipline("Bad Shit Crazy Magic"));

            school.Students.Add(new Student("Bugs Bunny"));
            school.Students.Add(new Student("Daffy Duck"));
            school.Students.Add(new Student("Elmer Fudd"));
            school.Students.Add(new Student("Marvin the Martian"));
        }
    }
}