using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
	public partial class Index : System.Web.UI.Page
	{
		protected void Sum(object sender, EventArgs e)
		{
			double result = double.Parse(this.First.Value) + double.Parse(this.Second.Value);
			this.Result.InnerText = result.ToString();
		}
	}
}