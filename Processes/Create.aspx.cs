using System;
using ProcessController.Models;
using ProcessController.Services;

namespace ProcessController.Processes
{
	public partial class Create : System.Web.UI.Page
	{
		ProcessService service = new ProcessService();

		protected void btnCreate_Click(object sender, EventArgs e)
		{
			string name = txtName.Text.Trim();

			if (string.IsNullOrEmpty(name))
			{
				lblMessage.Text = "⚠️ Process name is required!";
				return;
			}

			Process p = new Process
			{
				ProcessName = name,
				CurrentState = "Ready" // important for your lifecycle flow
			};

			service.AddProcess(p);

			Response.Redirect("Index.aspx");
		}
	}
}