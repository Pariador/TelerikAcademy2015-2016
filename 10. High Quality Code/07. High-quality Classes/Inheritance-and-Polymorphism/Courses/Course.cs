namespace InheritanceAndPolymorphism.Courses
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Course
    {
        protected const string PropFormat = "{0} = {1};";

        private string name;

        private string teacherName;

        private List<string> students;

        public Course(string name, string teacherName)
        {
            this.Name = name;
            this.TeacherName = teacherName;

            this.students = new List<string>();
        }

        public Course(string name, string teacherName, string[] students)
            : this(name, teacherName)
        {
            this.AddStudents(students);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be empty, null or whitespace.");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("TeacherName can't be empty, null or whitespace.");
                }

                this.teacherName = value;
            }
        }

        public void AddStudents(params string[] students)
        {
            string[] validatedStudents = new string[students.Length];

            for (int i = 0; i < students.Length; i++)
            {
                validatedStudents[i] = Course.ValidateStudent(students[i]);
            }

            this.students.AddRange(validatedStudents);
        }

        public string[] GetStudents()
        {
            return this.students.ToArray();
        }

        public string GetStudentsAsString()
        {
            return string.Format("{{{0}}}", string.Join(", ", this.students));
        }

        public override string ToString()
        {
            Queue<string> props = new Queue<string>();
            string name = string.Format(Course.PropFormat, "Name", this.Name);
            props.Enqueue(name);

            string teacher = string.Format(Course.PropFormat, "Teacher", this.TeacherName);
            props.Enqueue(teacher);

            string students = string.Format(Course.PropFormat, "Students", this.GetStudentsAsString());
            props.Enqueue(students);

            StringBuilder result = new StringBuilder();
            result.Append("Course = {");

            string propsAsStr = string.Join(" ", props);
            result.Append(propsAsStr);

            result.Append('}');
            return result.ToString();
        }

        protected static string ValidateStudent(string student)
        {
            student = student.Trim();
            if (string.IsNullOrEmpty(student))
            {
                throw new ArgumentException("Student can't be empty, null or whitespace.");
            }

            return student;
        }
    }
}