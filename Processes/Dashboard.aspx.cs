using System;
using System.Web.UI.WebControls;
using ProcessController.Services;

namespace ProcessController.Processes
{
	public partial class Dashboard : System.Web.UI.Page
	{
		ProcessService service = new ProcessService();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				gvLogs.DataSource = service.GetLogs();
				gvLogs.DataBind();
			}
		}

		protected void gvLogs_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				Label lbl = (Label)e.Row.FindControl("lblState");

				if (lbl != null)
				{
					string state = lbl.Text;

					if (state == "Running")
						lbl.CssClass = "badge bg-success";

					else if (state == "Waiting")
						lbl.CssClass = "badge bg-warning text-dark";

					else if (state == "Terminated")
						lbl.CssClass = "badge bg-danger";

					else if (state == "Ready")
						lbl.CssClass = "badge bg-secondary";
				}
			}
		}
	}
}