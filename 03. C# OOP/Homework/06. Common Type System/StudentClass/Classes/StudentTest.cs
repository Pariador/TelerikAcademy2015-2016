namespace StudentApp
{
    using System;

    public static class StudentTest
    {
        public static void Start()
        {
            var studentOne = new Student("Doctor", "Who", "1337", Universities.SoftwareUniversity);
            var studentTwo = new Student("Daleks", "Exterminate", "0000", Universities.SoftwareUniversity);

            var clone = (Student)studentTwo.Clone();

            Console.WriteLine("Are studentTwo and its clone equal: {0}", studentTwo == clone);
            Console.WriteLine("Are their hash codes equal: {0}", studentTwo.GetHashCode() == clone.GetHashCode());
            Console.WriteLine("Student one to student two comparison result: {0}", studentOne.CompareTo(studentTwo));
            Console.WriteLine(studentOne);
        }
    }
}