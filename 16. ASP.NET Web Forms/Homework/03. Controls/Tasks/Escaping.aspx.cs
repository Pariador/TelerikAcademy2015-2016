namespace Tasks
{
	using System;
	using System.Web.UI;

	public partial class Escaping : Page
	{
		protected void ReadHtml(object sender, EventArgs args)
		{
			this.label.Text = this.htmlInput.Text;
			this.literal.Text = this.htmlInput.Text;
			this.textBox.Text = this.htmlInput.Text;
		}
	}
}