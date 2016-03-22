namespace SchoolProgram
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SchoolClass : ICommentable
    {
        private static List<string> existingNames = new List<string>();
        private string name;
        private string comment;

        public SchoolClass(string name)
        {
            this.Name = name;

            if (SchoolClass.ExistingNames.Contains(this.Name))
            {
                throw new ArgumentException("A class with this name was alredy created.");
            }
            SchoolClass.ExistingNames.Add(this.Name);

            this.TeachersList = new List<Teacher>();
        }
        public SchoolClass(string name, params Teacher[] teachers) : this(name)
        {
            this.TeachersList.AddRange(teachers);
        }

        private static List<string> ExistingNames
        {
            get
            {
                return SchoolClass.existingNames;
            }
            set
            {
                SchoolClass.existingNames = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                value = value.Trim();

                if (String.IsNullOrEmpty(value) || value.Length > 30)
                {
                    throw new NameException();
                }

                this.name = value;
            }
        }
        public List<Teacher> TeachersList { get; private set; }
        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                value = value.Trim();

                if (String.IsNullOrEmpty(value))
                {
                    throw new CommentException();
                }

                this.comment = value;
            }
        }

        public Teacher Teacher
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}