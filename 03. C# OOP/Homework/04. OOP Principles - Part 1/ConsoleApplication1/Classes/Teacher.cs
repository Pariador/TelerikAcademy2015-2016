namespace SchoolProgram
{
    using System;
    using System.Collections.Generic;

    public class Teacher : Person, ICommentable
    {
        public Teacher(string name) : base(name)
        {
            this.TeacherID = Teacher.NextID;
            this.Disciplines = new List<Discipline>();
        }
        public Teacher(string name, params Discipline[] disciplines) : this(name)
        {
            this.Disciplines.AddRange(disciplines);
        }

        public ulong TeacherID { get; private set; }
        public List<Discipline> Disciplines { get; private set; }

        public Discipline Discipline
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