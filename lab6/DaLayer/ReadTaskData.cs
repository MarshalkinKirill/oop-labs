using System;
using System.Collections.Generic;
using System.Text;
using lab6;
using lab6.BlLayer;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace lab6.DaLayer
{
	class ReadTaskData
	{
		public List<Task> ReadTasksData(string path)
		{
			List<Task> tasklist = new List<Task>();
			tasklist = JsonSerializer.Deserialize<List<Task>>(File.ReadAllText(path));
			return tasklist;
		}
	}
}
