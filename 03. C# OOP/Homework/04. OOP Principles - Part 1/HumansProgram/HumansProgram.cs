namespace HumansProgram
{
    using System;
    using System.Linq;

    internal class EntryPoint
    {
        public static Random rand = new Random();

        internal static void Main()
        {
            Student[] students = new Student[10];
            for (int i = 0; i < students.Length; i++)
            {
                string firstName = String.Format("First Student{0}", i);
                string lastName = String.Format("Last Student{0}", i);
                double grade =  rand.Next(2, 6) + rand.NextDouble();

                students[i] = new Student(firstName, lastName, grade);
            }
            students = students.OrderBy(st => st.Grade).ToArray();

            Console.WriteLine("Students:");
            foreach (var student in students)
            {
                Console.WriteLine("{0} - Grade: {1:0.00}", student, student.Grade);
            }

            Worker[] workers = new Worker[10];
            for (int i = 0; i < workers.Length; i++)
            {
                string firstName = String.Format("First Worker{0}", i);
                string lastName = String.Format("Last Worker{0}", i);

                workers[i] = new Worker(firstName, lastName) 
                {
                    WorkHoursPerDay = rand.Next(4, 9),
                    WeekSalary = rand.Next(100, 1000)
                };
            }
            workers = workers.OrderByDescending(wrkr => wrkr.MoneyPerHour()).ToArray();

            Console.WriteLine("\nWorkers:");
            foreach (var worker in workers)
            {
                Console.WriteLine("{0} - Money:{1:0.00}", worker, worker.MoneyPerHour());
            }

            var allPeople = students.Cast<Human>()
                            .Concat(workers.Cast<Human>())
                            .OrderBy(prsn => prsn.FirstName)
                            .ThenBy(prsn => prsn.FirstName);

            Console.WriteLine("\nAll pleople sorted by name:");
            foreach (var person in allPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}