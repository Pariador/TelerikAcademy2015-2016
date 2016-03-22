namespace WebFormsApp
{
	using System;
	using System.Reflection;

	public partial class Index : System.Web.UI.Page
	{
		protected void Page_PreInit(object sender, EventArgs e)
		{
			// Added in Page_Init.
		}
		protected void Page_Init(object sender, EventArgs e)
		{
			this.lifeCycleList.InnerHtml += this.ListItem(nameof(this.Page_PreInit));

			this.lifeCycleList.InnerHtml += this.ListItem(nameof(this.Page_Init));
		}
		protected void Page_InitComplete(object sender, EventArgs e)
		{
			this.lifeCycleList.InnerHtml += this.ListItem(nameof(this.Page_InitComplete));
		}
		protected void Page_PreLoad(object sender, EventArgs e)
		{
			this.lifeCycleList.InnerHtml += this.ListItem(nameof(this.Page_PreLoad));
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.heading.InnerText = "Hello, ASP.NET";
			this.assembly.InnerText = Assembly.GetExecutingAssembly().Location;

			this.lifeCycleList.InnerHtml += this.ListItem(nameof(this.Page_Load));
		}

		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			this.lifeCycleList.InnerHtml += this.ListItem(nameof(this.Page_LoadComplete));
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			this.lifeCycleList.InnerHtml += this.ListItem(nameof(this.Page_PreRender));
		}

		protected void Page_PreRenderComplete(object sender, EventArgs e)
		{
			this.lifeCycleList.InnerHtml += this.ListItem(nameof(this.Page_PreRenderComplete));
		}

		protected void Page_SaveStateComplete(object sender, EventArgs e)
		{
			this.lifeCycleList.InnerHtml += this.ListItem(nameof(this.Page_SaveStateComplete));
			this.lifeCycleList.InnerHtml += this.ListItem(nameof(this.Page_Unload));
		}

		protected void Page_Unload(object sender, EventArgs e)
		{
			// Added in Page_SaveStateComplete.
		}

		private string ListItem(string content)
		{
			return $"<li>{content}</li>";
		}
	}
}