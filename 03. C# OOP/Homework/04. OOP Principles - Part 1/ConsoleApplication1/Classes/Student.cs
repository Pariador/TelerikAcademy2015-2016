namespace SchoolProgram
{
    using System;

    public class Student : Person, ICommentable
    {
        public Student(string name) : base(name)
        {
            this.StudentID = Student.NextID;
        }

        public ulong StudentID { get; private set; }
    }
}