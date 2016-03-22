namespace SchoolAppTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchoolApp.Library;

    [TestClass]
    public class StudentTests
    {
        public const string ValidName = "John";

        public const int ValidID = 24001;

        public const int InvalidID = 11;

        [TestMethod]
        public void CreateStudentWithValidNameAndID()
        {
            var student = new Student(StudentTests.ValidID, StudentTests.ValidName);

            Assert.AreEqual(StudentTests.ValidName, student.Name, "Students's name wasn't set correnctly.");
            Assert.AreEqual(StudentTests.ValidID, student.ID, "Student's ID wasn't correctly set.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStudentWithEmptyOrNullStringNameShouldThrowArgumentException()
        {
            var student = new Student(StudentTests.ValidID, "");
            student = new Student(StudentTests.ValidID, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetStudentNameToEmptyOrNullStringShouldThrowArgumentException()
        {
            var student = new Student(StudentTests.ValidID, StudentTests.ValidName);

            student.Name = "";
            student.Name = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateStudentWithOutOfRandeIDSHouldThrowArgumentOutOfRangeException()
        {
            int tooSmallID = Student.MinID - 1;
            int tooBigID = Student.MaxID + 1;

            var studentOne = new Student(tooSmallID, StudentTests.ValidName);
            var studentTwo = new Student(tooBigID, StudentTests.ValidName);
        }
    }
}