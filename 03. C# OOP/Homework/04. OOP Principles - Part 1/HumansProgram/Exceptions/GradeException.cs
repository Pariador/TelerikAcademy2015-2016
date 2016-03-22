namespace HumansProgram
{
    using System;

    public class GradeException : ApplicationException
    {
        public GradeException() : base("Grade must be a number between 2.00 and 6.00.")
        {
            ; 
        }
    }
}