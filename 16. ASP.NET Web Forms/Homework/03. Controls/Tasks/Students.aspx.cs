namespace Tasks
{
	using System;
	using System.Linq;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class Students : Page
	{
		protected void Register(object sender, EventArgs args)
		{
			string firstName = this.FirstName.Text;
			string lastName = this.LastName.Text;
			string facultyNumber = this.FacultyNumber.Text;
			string university = this.Universities.SelectedItem.Text;
			string speciality = this.Specialities.SelectedItem.Text;
			string courses = this.Courses.Items.Cast<ListItem>()
				.Where(item => item.Selected)
				.Select(item => item.Text)
				.Join(", ");

			string student = $"First Name: {firstName}, Last Name: {lastName}, Faculty Number: {facultyNumber}, University: {university}, Speciality: {speciality}, Courses: {courses}";
			this.RegisteredStudents.Items.Add(student);
		}
	}
}