namespace SchoolApp.Library
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class School
    {
        private int nextStudentID;

        private string name;

        private List<Student> students;

        private List<Course> courses;

        public School(string name)
        {
            this.Name = name;

            this.nextStudentID = Student.MinID;

            this.students = new List<Student>();
            this.courses = new List<Course>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be empty or null.");
                }

                this.name = value;
            }
        }

        private int GetNextStudentID() 
        {
            return this.nextStudentID++;
        }

        public void AddStudent(string name)
        {
            Student student = new Student(this.GetNextStudentID(), name);
            this.students.Add(student);
        }

        public Student[] GetStudetns()
        {
            return students.ToArray();
        }

        public void RemoveStudentByID(int id)
        {
            int beforeCount = students.Count;

            students.RemoveAll(st => st.ID == id);

            if (beforeCount == students.Count)
            {
                string message = string.Format("Student with id: [{0}] wasn't found.", id);
                throw new ArgumentException(message);
            }
        }

        public void AddCouse(string name)
        {
            if (this.courses.Any(course => course.Name == name))
            {
                string message = string.Format("A course with name: [{0}] has alredy been added to the school.", name);
                throw new ArgumentException(message);
            }

            this.courses.Add(new Course(name));
        }

        public Course[] GetCourses()
        {
            return courses.ToArray();
        }

        public void RemoveCouseByName(string name)
        {
            int beforeCount = this.courses.Count;

            this.courses.RemoveAll(course => course.Name == name);

            if (beforeCount == this.courses.Count)
            {
                string message =  string.Format("Course with name: [{0}] wasn't found.", name);
                throw new ArgumentException(message);
            }
        }

        public void AssignStudentToCourse(int studentID, string courseName)
        {
            Student student;
            try
            {
                student = this.students.First(st => st.ID == studentID);
            }
            catch (InvalidOperationException)
            {
                string message = string.Format("Student with id: [{0}] wasn't found.", studentID);
                throw new ArgumentException(message);
            }

            Course course;
            try
            {
                course = this.courses.First(crs => crs.Name == courseName);
            }
            catch (InvalidOperationException)
            {
                string message = string.Format("Course with name: [{0}] wasn't found.", courseName);
                throw new ArgumentException(message);
            }

            course.AddStudent(student);
        }
    }
}