using System;
using System.Web.UI.WebControls;
using ProcessController.Services;

namespace ProcessController.Processes
{
	public partial class Index : System.Web.UI.Page
	{
		ProcessService service = new ProcessService();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				gvProcesses.DataSource = service.GetProcesses();
				gvProcesses.DataBind();
			}
		}

		protected void gvProcesses_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				Label lblState = (Label)e.Row.FindControl("lblState");

				if (lblState != null)
				{
					string state = lblState.Text;

					if (state == "Running")
						lblState.CssClass = "badge bg-success";

					else if (state == "Waiting")
						lblState.CssClass = "badge bg-warning text-dark";

					else if (state == "Terminated")
						lblState.CssClass = "badge bg-danger";

					else if (state == "Ready")
						lblState.CssClass = "badge bg-secondary";
				}
			}
		}
	}
}