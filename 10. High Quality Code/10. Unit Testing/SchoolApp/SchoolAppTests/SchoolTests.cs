namespace SchoolAppTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchoolApp.Library;

    [TestClass]
    public class SchoolTests
    {
        public const string ValidName = "Telerik Academy";

        [TestMethod]
        public void CreateSchoolWithValidName()
        {
            var school = new School(SchoolTests.ValidName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolCreatedWithEmptyOrNullStringNameShouldThrowArgumentExcenption()
        {
            var school = new School("");
            school = new School(null);
        }

        [TestMethod]
        public void TestAddStudentAndGetStudents()
        {
            var school = new School(SchoolTests.ValidName);
            var names = new string[10];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = string.Format("Student[{0}]", i);
                school.AddStudent(names[i]);
            }

            var studentsInSchool = school.GetStudetns();

            foreach (var student in studentsInSchool)
            {
                Assert.IsTrue(names.Contains(student.Name), "An added student could not be retrieved.");
            }
        }

        [TestMethod]
        public void GetStudentsShouldNotReturnReference()
        {
            var school = new School(SchoolTests.ValidName);
            school.AddStudent("Jane");

            var studentsInSchool = school.GetStudetns();

            studentsInSchool[0] = new Student(Student.MinID, "NotJane");

            studentsInSchool = school.GetStudetns();

            Assert.AreEqual(studentsInSchool[0].Name, "Jane", "GetStudents returned a refrence.");
        }

        [TestMethod]
        public void TestIfAllAddedStudentsHaveUniqueID()
        {
            var school = new School(SchoolTests.ValidName);

            for (int i = 0; i < 1000; i++)
            {
                string name = string.Format("Student[{0}]", i);
                school.AddStudent(name);
            }

            var studentsInSchool = school.GetStudetns();

            HashSet<int> uniqueIDs = new HashSet<int>();

            foreach (var student in studentsInSchool)
            {
                uniqueIDs.Add(student.ID);
            }

            Assert.AreEqual(studentsInSchool.Length, uniqueIDs.Count, "Not all students have unique IDs.");
        }

        [TestMethod]
        public void TestRemoveStudentByID()
        {
            var school = new School(CourseTests.ValidName);
            school.AddStudent("John");
            school.AddStudent("Derik");
            school.AddStudent("Miria");

            var studentsBeforeRemove = school.GetStudetns();

            var removedStudent = studentsBeforeRemove[0];
            school.RemoveStudentByID(removedStudent.ID);

            var studentsAfterRemove = school.GetStudetns();

            Assert.AreEqual(studentsBeforeRemove.Length - 1, studentsAfterRemove.Length, "No students were removed.");

            Assert.IsFalse(studentsAfterRemove.Any(st => st.ID == removedStudent.ID), "Wrong student was removed.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveStudentByIDWithInvalidIDShouldThrowArgumentException()
        {
            var school = new School(SchoolTests.ValidName);

            school.RemoveStudentByID(7);
        }

        [TestMethod]
        public void TestAddCourseAndGetCourses()
        {
            var school = new School(SchoolTests.ValidName);

            string[] courseNames = { "JS", "C#", "How to Batman 101" };

            foreach (var name in courseNames)
            {
                school.AddCouse(name);
            }

            var cousesInSchool = school.GetCourses();

            foreach (var course in cousesInSchool)
            {
                Assert.IsTrue(courseNames.Contains(course.Name), "Not all added courses were retrieved.");
            }
        }

        [TestMethod]
        public void GetCoursesShouldNotReturnReference()
        {
            const string OriginalCourseName = "How to touch buts"; 

            var school = new School(SchoolTests.ValidName);
            school.AddCouse(OriginalCourseName);

            var coursesInSchool = school.GetCourses();

            coursesInSchool[0] = new Course("Watching paint dry");

            coursesInSchool = school.GetCourses();
            Assert.AreEqual(coursesInSchool[0].Name, OriginalCourseName, "GetCourses returned a reference");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExpectArgumentExceptionWhenCoursesWithTheSameNamesAreAdded()
        {
            var school = new School(SchoolTests.ValidName);
            school.AddCouse("How to cat");
            school.AddCouse("How to cat");
        }

        [TestMethod]
        public void TestRemoveCourseByName()
        {
            var school = new School(SchoolTests.ValidName);
            school.AddCouse("Pie in the face");
            school.AddCouse("Spiderman");

            school.RemoveCouseByName("Spiderman");

            var coursesInSchool = school.GetCourses();

            Assert.AreEqual(coursesInSchool.Length, 1, "Course wasn't removed.");
            Assert.AreEqual(coursesInSchool[0].Name, "Pie in the face", "Incorrect course was removed.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingCourseByNameShouldThrowArgumentExceptionIfTheCourseIsNotFound()
        {
            var school = new School(SchoolTests.ValidName);
            school.RemoveCouseByName("Livin' La Vida Loca");
        }

        [TestMethod]
        public void TestAssignStudentToCourse()
        {
            const string CourseName = "(╯°□°）╯︵ ┻━┻)";
            const string StudentName = "JSProgrammer";

            var school = new School(SchoolTests.ValidName);
            school.AddCouse(CourseName);
            school.AddStudent(StudentName);

            var student = school.GetStudetns()[0];

            school.AssignStudentToCourse(student.ID, CourseName);

            var course = school.GetCourses()[0];

            Assert.IsTrue(course.GetStudents().Any(st => st.Name == StudentName));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AssignStudentToCourseWithInvalidDataShouldThrowArgumentException()
        {
            var school = new School(SchoolTests.ValidName);

            school.AssignStudentToCourse(13, "World of Warcraft");
        }
    }
}