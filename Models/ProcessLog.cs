using System;

namespace ProcessController.Models
{
	public class ProcessLog
	{
		public int LogID { get; set; }
		public int ProcessID { get; set; }
		public string State { get; set; }
		public DateTime Timestamp { get; set; }
	}
}