namespace InheritanceAndPolymorphism.Courses
{
    using System;
    using System.Text;

    public class LocalCourse : Course
    {        
        private string lab;

        public LocalCourse(string name, string teacherName, string lab)
            : base(name, teacherName)
        {
            this.Lab = lab;
        }

        public LocalCourse(string name, string teacherName, string lab, string[] students)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Lab can't be empty, null or whitespace.");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Insert(0, "Local");

            string lab = string.Format(Course.PropFormat, "Lab", this.lab);
            result.Insert(result.Length - 1, ' ');
            result.Insert(result.Length - 1, lab);

            return result.ToString();
        }
    }
}