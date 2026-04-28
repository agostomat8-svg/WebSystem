using System;

namespace ProcessController.Models
{
	public class Process
	{
		public int ProcessID { get; set; }
		public string ProcessName { get; set; }
		public string CurrentState { get; set; }
	}
}