namespace PhoneClassLibrary
{
    using System;
    using System.Text;

    class Call
    {
        private const string unknownStart = "[Unknown Date and Time]";
        private const string unknownDuration = "[Unknown Duration]";

        private string calledNumber;
        private DateTime? callStart;
        private TimeSpan? callDuration;

        public Call(string number)
        {
            this.CalledNubmer = number;
            this.callStart = null;
            this.callDuration = null;
        }
        public Call(string number, DateTime callStart) : this(number)
        {
            this.CallStart = callStart;
        }
        public Call(string number, DateTime callStart, TimeSpan callDuration) : this(number, callStart)
        {
            this.CallDuration = callDuration;
        }

        public string CalledNubmer 
        {
            get
            {
                return this.calledNumber;
            }
            set
            {
                value = value.Trim();
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("CalledNumber can't be empty, null or whirepace.");
                }

                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException("CalledNumber can't be shorter than 3 or longer than 15 characters.");
                }

                this.calledNumber = value;
            }
        }
        public DateTime? CallStart
        {
            get
            {
                return this.callStart;
            }
            set
            {
                this.callStart = value;
            }
        }
        public TimeSpan? CallDuration
        {
            get
            {
                return this.callDuration;
            }
            set
            {
                this.callDuration = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            const string placeHolder = "{0}: {1}, ";
            const string endHolder = "{0}: {1}";
            const string calledNumber = "Called Number";
            const string callStart = "Call Start";
            const string callDuration = "Call Duration";

            result.Append(String.Format(placeHolder, calledNumber, this.CalledNubmer));
            if (this.CallStart != null)
            {
                result.Append(String.Format(placeHolder, callStart, this.CallStart));
            }
            else
            {
                result.Append(String.Format(placeHolder, callStart, unknownStart));
            }

            if (this.CallDuration != null)
            {
                result.Append(String.Format(endHolder, callDuration, this.CallDuration));
            }
            else
            {
                result.Append(String.Format(endHolder, callDuration, unknownDuration));
            }

            return result.ToString();
        }
    }
}