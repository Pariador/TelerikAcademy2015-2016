namespace ConsoleClient
{
    using System;
    using System.Linq;

    using Students.Data;
    using Students.Data.Models;

    public static class DataImporter
    {
        public static void ImportStudents(int count)
        {
            Console.WriteLine("Importing Students...");

            var db = new StudentsDbContext();

            var allCourses = db.Courses.ToList();

            for (int i = 0; i < count; i++)
            {
                if (count % 100 == 0)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new StudentsDbContext();
                }

                string firstName = RandomGenerator.GetString(1, 50);

                string lastName = RandomGenerator.GetString(1, 50);

                Student student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                if (allCourses.Count != 0)
                {
                    int coursesNumber = RandomGenerator.GetInt(1, allCourses.Count);
                    var avaliableCourses = allCourses.ToList();
                    for (int j = 0; j < coursesNumber; j++)
                    {
                        Course course = RandomGenerator.GetFromList<Course>(avaliableCourses);
                        student.Courses.Add(course);
                        avaliableCourses.Remove(course);
                    }
                }

                db.Students.Add(student);
            }

            db.SaveChanges();
            db.Dispose();
        }

        public static void ImportCourses(int count)
        {
            Console.WriteLine("Importing Courses...");

            var db = new StudentsDbContext();

            var allStudents = db.Students.ToList();

            for (int i = 0; i < count; i++)
            {
                if (count % 100 == 0)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new StudentsDbContext();
                }

                string name = RandomGenerator.GetString(1, 50);

                string description = RandomGenerator.GetString(10, 200);

                Course course = new Course
                {
                    Name = name,
                    Description = description
                };

                if (allStudents.Count != 0)
                {
                    int studentCount = RandomGenerator.GetInt(1, allStudents.Count);
                    var avaliableStudents = allStudents.ToList();
                    for (int j = 0; j < studentCount; j++)
                    {
                        Student student = RandomGenerator.GetFromList<Student>(avaliableStudents);
                        course.Students.Add(student);
                        avaliableStudents.Remove(student);
                    }
                }

                db.Courses.Add(course);
            }

            db.SaveChanges();
            db.Dispose();
        }

        public static void ImportHomeworks(int count)
        {
            Console.WriteLine("Importing Homeworks...");

            var db = new StudentsDbContext();

            var studentIds = db.Students.Select(s => s.Id).ToList();

            var coursesIds = db.Courses.Select(c => c.Id).ToList();

            for (int i = 0; i < count; i++)
            {
                if (count % 100 == 0)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new StudentsDbContext();
                }

                string content = RandomGenerator.GetString(10, 1000);

                DateTime timeSent = RandomGenerator.GetDateTime();

                int studentId = RandomGenerator.GetFromList<int>(studentIds);
                int courseId = RandomGenerator.GetFromList<int>(coursesIds);

                Homework homework = new Homework 
                {
                    Content = content,
                    TimeSent = timeSent,
                    StudentId = studentId,
                    CourseId = courseId
                };

                db.Homeworks.Add(homework);
            }

            db.SaveChanges();
            db.Dispose();
        }
    }
}