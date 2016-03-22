namespace SchoolAppTests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchoolApp.Library;

    [TestClass]
    public class CourseTests
    {
        public const string ValidName = "JavaScript";

        [TestMethod]
        public void CreateCourseWithValidName()
        {
            var course = new Course(CourseTests.ValidName);

            Assert.AreEqual(course.Name, CourseTests.ValidName, "Course name wasn't set correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCourseWithNullOrEmptyNameShouldThrowArgumentException()
        {
            var course = new Course("");
            course = new Course(null);
        }

        [TestMethod]
        public void AddStudentAndGetStudentsWithOneStudent()
        {
            var student = new Student(Student.MinID, "John");
            var course = new Course(CourseTests.ValidName);

            course.AddStudent(student);

            var getResult = course.GetStudents()[0];

            Assert.AreEqual(getResult.ID, student.ID, "Added student wasn't returned.");
        }

        [TestMethod]
        public void GetStudentShouldNotReturnReference()
        {
            var student = new Student(Student.MinID, "Neo");
            var course = new Course(CourseTests.ValidName);

            course.AddStudent(student);

            var students = course.GetStudents();
            var newStudent = new Student(Student.MaxID, "Ana");
            students[0] = newStudent;

            students = course.GetStudents();
            var courseStudent = students[0];

            Assert.AreNotEqual(courseStudent.ID, newStudent.ID, "GetStudents returns a reference.");
        }

        [TestMethod]
        public void RemoveStudentByIDShouldRemoveCorrectStudent()
        {
            var student = new Student(Student.MinID, "Arin");
            var otherSudent = new Student(Student.MaxID, "Alice");
            var course = new Course(CourseTests.ValidName);

            course.AddStudent(student);
            course.AddStudent(otherSudent);

            course.RemoveStudentByID(otherSudent.ID);

            var students = course.GetStudents();

            Assert.AreEqual(students.Length, 1, "RemoveStudentByID doesn't remove a student.");

            Assert.AreEqual(students[0].ID, student.ID, "RemoveStudentByID doesn't remove the correct student.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingMoreThanTheMaxAmountOfStudentsShouldThrowArgumentException()
        {
            var course = new Course(CourseTests.ValidName);
            for (int i = 0; i < Course.MaxStudentsPerCourse + 1; i++)
            {
                string name = string.Format("John[{0}]", i);
                course.AddStudent(new Student(Student.MinID + i, name));
            }
        }

        [TestMethod]
        public void TestAddingStudentsArrInConstructor()
        {
            Student[] students = { new Student(Student.MinID, "Vern"), new Student(Student.MaxID, "Nancy") };
            var course = new Course(CourseTests.ValidName);

            var studetnsInCourse = course.GetStudents();

            Assert.IsTrue(studetnsInCourse.All(stdnt => students.Any(st => stdnt.ID == st.ID)));
        }
    }
}