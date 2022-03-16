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
	public class ReadEmployeeData
	{

		public List<Employee> ReadEmployeData(string path)
		{
			List<Employee> employeelist = new List<Employee>();
			employeelist = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(path));
			return employeelist;
		}
	}
}
/*using (var sr = new StreamReader(path))
			{
				Console.WriteLine(sr.ReadToEnd());
			}*/
