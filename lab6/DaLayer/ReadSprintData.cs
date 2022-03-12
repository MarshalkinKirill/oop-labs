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
	class ReadSprintData
	{
		public List<Sprint> ReadTSprintsData(string path)
		{
			List<Sprint> sprintlist = new List<Sprint>();
			sprintlist = JsonSerializer.Deserialize<List<Sprint>>(File.ReadAllText(path));
			return sprintlist;
		}
	}
}
