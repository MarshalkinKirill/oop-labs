using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using lab6.BlLayer;

namespace lab6.DaLayer
{
	public class InitSprintData
	{
		private string SprintPath;
		private List<Sprint> SprintDataList;
		public InitSprintData(string path)
		{
			SprintPath = path;
			SprintDataList = new List<Sprint>();
			InitFile(path);
			SprintDataList.Add(new Sprint(111, new DateTime(2022, 3, 11), new DateTime(2022, 3, 18)));
			SaveSplit(SprintDataList, path);
		}
		private void InitFile(string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		private void SaveSplit(List<Sprint> sprints, string path)
		{

			File.AppendAllText(path, JsonSerializer.Serialize(sprints));
		}
		public void AddSprint(Sprint sprint)
		{
			InitFile(SprintPath);
			SprintDataList.Add(sprint);
			SaveSplit(SprintDataList, SprintPath);
		}
	}
}
