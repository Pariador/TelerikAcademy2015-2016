namespace Tasks
{
	using System;
	using System.Web.UI;

	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs args)
		{
			this.Page.Title = "WebForms Swag!!!";
		}
	}
}