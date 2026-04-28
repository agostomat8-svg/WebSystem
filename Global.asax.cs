using System;

namespace ProcessController
{
	public class Global : System.Web.HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			// ❌ REMOVE Optimization and Bundles (causes crash)

			// If you are NOT using routing, leave this EMPTY
			// This is safe for WebForms projects
		}
	}
}