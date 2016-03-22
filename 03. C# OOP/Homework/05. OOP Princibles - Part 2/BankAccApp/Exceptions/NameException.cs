namespace BankAccApp
{
    using System;

    public class NameException : ApplicationException
    {
        public NameException() : base("Name must be 1-30 chars and not whitespace.")
        {
            ;
        }
    }
}