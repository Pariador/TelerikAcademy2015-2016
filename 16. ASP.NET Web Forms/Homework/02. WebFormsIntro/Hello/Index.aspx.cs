namespace Hello
{
	using System;

	public partial class Index : System.Web.UI.Page
	{
		protected void Display(object sender, EventArgs e)
		{
			string name = this.name.Text;
			this.result.Text = $"Name {name}.";
		}
	}
}