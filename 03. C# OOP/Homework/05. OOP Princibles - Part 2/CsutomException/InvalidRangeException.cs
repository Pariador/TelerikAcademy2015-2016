namespace CustomException
{
    using System;

    public class InvalidRangeException<T> : ApplicationException where T : IComparable
    {
        public InvalidRangeException(T start, T end) : base()
        {
            int result = start.CompareTo(end);
            if (result == 1 || result == 0)
            {
                throw new ArgumentException("Start mustn't be equal or more than end.");
            }

            this.Start = start;
            this.End = end;
        }

        public T Start { get; private set; }
        public T End { get; private set; }
        public override string Message
        {
            get
            {
                return String.Format("Value was not in range {0} - {1}.", this.Start, this.End);
            }
        }
    }
}