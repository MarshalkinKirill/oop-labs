using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using lab6.BlLayer;

namespace lab6.DaLayer
{
	public class InitTaskData
	{
		private string TaskPath;
		private List<Task> TasksList;
		public InitTaskData(string path)
		{
			TaskPath = path;
			TasksList = new List<Task>();
			InitFile(path);
			TasksList.Add(new Task(123, 111, "Task1", "do nothing", 1));
			SaveTasks(TasksList, path);
		}
		private void InitFile(string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		private void SaveTasks(List<Task> tasks, string path)
		{

			File.AppendAllText(path, JsonSerializer.Serialize(tasks));
		}
		public void AddTask(Task task)
		{
			TasksList.Add(task);
			InitFile(TaskPath);
			SaveTasks(TasksList, TaskPath);
		}
		public void UpdateTask(int id, Task changes)
		{
			var changedtask = TasksList.Find(item => item.TaskID == (id));
			TasksList.Remove(changedtask);
			TasksList.Add(changes);
			InitFile(TaskPath);
			SaveTasks(TasksList, TaskPath);
		}
	}
}
