namespace InheritanceAndPolymorphism.Courses
{
    using System;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name, string teacherName, string town)
            : base(name, teacherName)
        {
            this.Town = town;
        }

        public OffsiteCourse(string name, string teacherName, string town, string[] students)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Town can't be empty, null or whitespace.");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Insert(0, "Offsite");

            string town = string.Format(Course.PropFormat, "Town", this.town);
            result.Insert(result.Length - 1, ' ');
            result.Insert(result.Length - 1, town);

            return result.ToString();
        }
    }
}