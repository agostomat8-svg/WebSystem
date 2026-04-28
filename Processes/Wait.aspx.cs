using System;
using ProcessController.Services;

namespace ProcessController.Processes
{
	public partial class Wait : System.Web.UI.Page
	{
		ProcessService service = new ProcessService();

		protected void Page_Load(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(Request.QueryString["id"]);
			service.UpdateState(id, "Waiting");

			Response.Redirect("Index.aspx");
		}
	}
}