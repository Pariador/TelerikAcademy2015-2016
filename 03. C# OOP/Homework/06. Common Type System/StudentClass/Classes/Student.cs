namespace StudentApp
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string adress;
        private string phone;
        private string eMail;
        private string course;

        public Student(string firstName, string lastName, string ssn,  Universities university)
        {
            this.FirstName = firstName;
            this.MiddleName = null;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Adress = null;
            this.Phone = null;
            this.EMail = null;
            this.Course = null;
            this.University = university;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                value = Validator.EmptyNullStr(value, "FirstName");
                Validator.NameLength(value);

                this.firstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                value = Validator.EmptyStr(value, "MiddleName");
                
                Validator.NameLength(value);

                this.middleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                value = Validator.EmptyNullStr(value, "LastName");
                Validator.NameLength(value);

                this.lastName = value;
            }
        }
        public string SSN
        {
            get
            {
                return this.ssn;
            }
            set
            {
                this.ssn = Validator.EmptyNullStr(value, "SSN");
            }
        }
        public string Adress
        {
            get
            {
                return this.adress;
            }
            set
            {
                this.adress = Validator.EmptyStr(value, "Adress");
            }
        }
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = Validator.EmptyStr(value, "Phone");
            }
        }
        public string EMail
        {
            get
            {
                return this.eMail;
            }
            set
            {
                this.eMail = Validator.EmptyStr(value, "EMail");
            }
        }
        public string Course
        {
            get
            {
                return this.course;
            }
            set
            {
                this.course = Validator.EmptyStr(value, "Course");
            }
        }
        public Specialties Specialty { get; set; }
        public Universities University { get; set; }
        public Faculties Faculty { get; set; }

        public override int GetHashCode()
        {
            char result = this.FirstName[0];

            for (int i = 1; i < this.FirstName.Length; i++)
            {
                result ^= this.FirstName[i];
            }

            for (int i = 0; i < this.LastName.Length; i++)
            {
                result ^= this.LastName[i];
            }

            for (int i = 0; i < this.SSN.Length; i++)
            {
                result ^= this.SSN[i];
            }

            return (int)result;
        }
        public override bool Equals(object obj)
        {
            Student other = obj as Student;

            if (other != null)
            {
                return this.Equals(other);
            }

            return false;
        }
        public bool Equals(Student other)
        {
            return this.FirstName == other.FirstName && this.LastName == other.LastName && this.SSN == other.SSN;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} SSN: {2}", this.FirstName, this.LastName, this.SSN);
        }
        public object Clone()
        {
            Student clone = new Student((string)this.FirstName.Clone(), (string)this.LastName.Clone(), (string)this.SSN.Clone(), this.University)
            {
                Specialty = this.Specialty,
                University = this.University,
                Faculty = this.Faculty
            };

            if (this.MiddleName != null)
            {
                clone.MiddleName = (string)this.MiddleName.Clone();
            }

            if (this.Adress != null)
            {
                clone.Adress = (string)this.Adress.Clone();
            }

            if (this.Phone != null)
            {
                clone.Phone = (string)this.Phone.Clone();
            }

            if (this.EMail != null)
            {
                clone.EMail = (string)this.EMail.Clone();
            }

            if (this.Course != null)
            {
                clone.Course = (string)this.Course.Clone();
            }

            return clone;
        }
        public int CompareTo(Student other)
        {
            int compareResult = this.FirstName.CompareTo(other.FirstName);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = this.LastName.CompareTo(other.LastName);
            if (compareResult != 0)
            {
                return compareResult;
            }

            return this.SSN.CompareTo(other.SSN);
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Equals(secondStudent);
        }
        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !(firstStudent == secondStudent);
        }
    }
}