namespace Memento
{
    public static class Program
    {
        public static void Main()
        {
            Person person = new Person("John", 21);
            person.Introduce();

            PersonMemento memento = person.Save();
            person.Name = "Jane";
            person.Introduce();

            person.Restore(memento);
            person.Introduce();
        }
    }
}