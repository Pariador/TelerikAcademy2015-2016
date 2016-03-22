namespace ConsoleClient
{
    using System;
    using System.Data.Entity;

    using Students.Data;
    using Students.Data.Models;
    using Students.Data.Migrations;

    public class Start
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsDbContext, Configuration>());

            DataImporter.ImportStudents(50);
            DataImporter.ImportCourses(50);
            DataImporter.ImportHomeworks(50);
        }
    }
}