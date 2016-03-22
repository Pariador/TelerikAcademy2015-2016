namespace SchoolProgram
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        public School()
        {
            this.Clases = new List<SchoolClass>();
            this.Students = new List<Student>();
        }

        public List<Student> Students { get; private set; }
        public List<SchoolClass> Clases { get; private set; }

        public SchoolClass SchoolClass
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Student Student
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}