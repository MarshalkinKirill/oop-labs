using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using lab6;
using lab6.BlLayer;

namespace lab6.DaLayer
{
	public class ReadLogData
	{
		public List<TaskChange> ReadLogsData(string path)
		{
			List<TaskChange> Changeslist = new List<TaskChange>();
			Changeslist = JsonSerializer.Deserialize<List<TaskChange>>(File.ReadAllText(path));
			return Changeslist;
		}
	}
}
