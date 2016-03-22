namespace Students.Data
{
    using System.Data.Entity;

    using Models;

    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext()
            : base("Students")
        {
            ;
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }
    }
}