namespace SchoolProgram
{
    using System;

    public abstract class Person : ICommentable
    {
        private static ulong nextID = 1;
        private string name;
        private string comment;

        protected Person(string name)
        {
            this.Name = name;
        }

        protected static ulong NextID
        {
            get
            {
                return Student.nextID++;
            }
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
            return object.ReferenceEquals(this, obj);
        }
        public override string ToString()
        {
            return this.Name;
        }

    }
}