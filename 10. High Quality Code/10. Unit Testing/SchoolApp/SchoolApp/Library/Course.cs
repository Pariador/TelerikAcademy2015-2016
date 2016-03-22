namespace SchoolApp.Library
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Course
    {
        public const int MaxStudentsPerCourse = 30;

        private string name;

        private List<Student> students;

        public Course(string name)
        {
            this.Name = name;

            this.students = new List<Student>();
        }

        public Course(string name, Student[] students)
            : this(name)
        {
            this.students.AddRange(students);
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

        public void AddStudent(Student student)
        {
            if (Course.MaxStudentsPerCourse == this.students.Count)
            {
                string message = string.Format("No more than {0} students can't be added to a course.", Course.MaxStudentsPerCourse);
                throw new ArgumentException(message);
            }

            this.students.Add(student);
        }
        public void RemoveStudentByID(int id)
        {
            this.students.RemoveAll(st => st.ID == id);
        }

        public Student[] GetStudents()
        {
            return this.students.ToArray();
        }
    }
}