namespace OrderedStudents
{
	public class Student
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Course { get; set; }

		public override string ToString()
		{
			return string.Format("FirstName: {0} | LastName: {1} | Course: {2}", this.FirstName, this.LastName, this.Course);
		}
	}
}