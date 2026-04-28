using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using ProcessController.Models;

namespace ProcessController.Services
{
	public class ProcessService
	{

		private string connectionString;

		public ProcessService()
		{
			connectionString = ConfigurationManager.ConnectionStrings["ProcessDB"].ConnectionString;
		}

		public SqlConnection GetConnection()
		{
			return new SqlConnection(connectionString);
		}
		// GET PROCESSES
		public List<Process> GetProcesses()
		{
			List<Process> list = new List<Process>();

			using (SqlConnection con = GetConnection())
			{
				con.Open();

				SqlCommand cmd = new SqlCommand("SELECT * FROM Processes", con);
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					list.Add(new Process
					{
						ProcessID = Convert.ToInt32(dr["ProcessID"]),
						ProcessName = dr["ProcessName"].ToString(),
						CurrentState = dr["CurrentState"].ToString()
					});
				}
			}

			return list;
		}

		// GET LOGS
		public List<ProcessLog> GetLogs()
		{
			List<ProcessLog> list = new List<ProcessLog>();

			using (SqlConnection con = GetConnection())
			{
				con.Open();

				SqlCommand cmd = new SqlCommand(
					"SELECT * FROM ProcessLogs ORDER BY Timestamp DESC", con);

				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					list.Add(new ProcessLog
					{
						LogID = Convert.ToInt32(dr["LogID"]),
						ProcessID = Convert.ToInt32(dr["ProcessID"]),
						State = dr["State"].ToString(),
						Timestamp = Convert.ToDateTime(dr["Timestamp"])
					});
				}
			}

			return list;
		}

		// ADD PROCESS
		public void AddProcess(Process p)
		{
			using (SqlConnection con = GetConnection())
			{
				con.Open();

				SqlCommand cmd = new SqlCommand(
					"INSERT INTO Processes (ProcessName, CurrentState) VALUES (@name, 'Ready')", con);

				cmd.Parameters.AddWithValue("@name", p.ProcessName);
				cmd.ExecuteNonQuery();

				// GET NEW ID
				SqlCommand getId = new SqlCommand(
					"SELECT TOP 1 ProcessID FROM Processes ORDER BY ProcessID DESC", con);

				int id = Convert.ToInt32(getId.ExecuteScalar());

				AddLog(id, "Ready");
			}
		}

		public void UpdateState(int id, string state)
		{
			using (SqlConnection con = GetConnection())
			{
				con.Open();

				// GET CURRENT STATE FIRST
				SqlCommand getState = new SqlCommand(
					"SELECT CurrentState FROM Processes WHERE ProcessID = @id", con);

				getState.Parameters.AddWithValue("@id", id);

				object result = getState.ExecuteScalar();

				if (result == null) return;

				string currentState = result.ToString();

				//  BLOCK IF TERMINATED
				if (currentState == "Terminated")
					return;

				// PREVENT INVALID SELF-LOOP (optional safety)
				if (currentState == state)
					return;

				// UPDATE STATE
				SqlCommand cmd = new SqlCommand(
					"UPDATE Processes SET CurrentState = @state WHERE ProcessID = @id", con);

				cmd.Parameters.AddWithValue("@state", state);
				cmd.Parameters.AddWithValue("@id", id);
				cmd.ExecuteNonQuery();

				// LOG IT
				AddLog(id, state);
			}
		}

		// ADD LOG
		private void AddLog(int processId, string state)
		{
			using (SqlConnection con = GetConnection())
			{
				con.Open();

				SqlCommand cmd = new SqlCommand(
					"INSERT INTO ProcessLogs (ProcessID, State, Timestamp) VALUES (@pid, @state, GETDATE())", con);

				cmd.Parameters.AddWithValue("@pid", processId);
				cmd.Parameters.AddWithValue("@state", state);

				cmd.ExecuteNonQuery();
			}
		}
	}
}