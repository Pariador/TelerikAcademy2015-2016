namespace SchoolProgram
{
    using System;

    public class CommentException : ApplicationException
    {
        public CommentException() : base("Comment can't be set to emtpty null or whitespace.")
        {
            ;
        }
    }
}