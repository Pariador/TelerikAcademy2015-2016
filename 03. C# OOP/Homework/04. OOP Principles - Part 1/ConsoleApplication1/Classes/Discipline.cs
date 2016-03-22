namespace SchoolProgram
{
    using System;

    public class Discipline : ICommentable
    {
        private string name;
        private int lecturesCount;
        private int exercisesCount;
        private string comment;

        public Discipline(string name)
        {
            this.Name = name;
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

                if (String.IsNullOrEmpty(value) || value.Length > 30)
                {
                    throw new NameException();
                }

                this.name = value;
            }
        }
        public int LecturesCount
        {
            get
            {
                return this.lecturesCount;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ApplicationException("LecturesCount needs to be between 0 and 100.");
                }

                this.lecturesCount = value;
            }
        }
        public int ExercisesCount
        {
            get
            {
                return this.lecturesCount;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ApplicationException("ExercisesCount needs to be between 0 and 100.");
                }

                this.lecturesCount = value;
            }
        }

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
    
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Discipline other = obj as Discipline;
            if (other != null)
            {
                return this.Name == other.Name && 
                       this.LecturesCount == other.LecturesCount && 
                       this.ExercisesCount == other.ExercisesCount;
            }

            return false;
        }
        public bool Equals(Discipline other)
        {
            return this.Name == other.Name &&
                   this.LecturesCount == other.LecturesCount &&
                   this.ExercisesCount == other.ExercisesCount;
        }
        public override string ToString()
        {
            return this.name;
        }

        public static bool operator ==(Discipline firstDiscipline, Discipline secondDiscipline)
        {
            return firstDiscipline.Equals(secondDiscipline);
        }
        public static bool operator !=(Discipline firstDiscipline, Discipline secondDiscipline)
        {
            return !(firstDiscipline == secondDiscipline);
        }
    }
}