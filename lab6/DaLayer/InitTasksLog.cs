using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using lab6.BlLayer;

namespace lab6.DaLayer
{
	public class InitTasksLog
	{
		private List<TaskChange> Logs;
		private string LogPath;
		public InitTasksLog(string path)
		{
			Logs = new List<TaskChange>();
			InitFile(path);
			LogPath = path;
			SaveLogs(Logs, path);
		}
		private void InitFile(string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		private void SaveLogs(List<TaskChange> taskchanges, string path)
		{

			File.AppendAllText(path, JsonSerializer.Serialize(taskchanges));
		}
		public void AddLog(List<TaskChange> change)
		{
			InitFile(LogPath);
			foreach(TaskChange ch in change)
			{
				Logs.Add(ch);
			}
			SaveLogs(Logs, LogPath);
		}
	}
}
