using System;
using System.Collections.Generic;
using System.Text;
using lab6.BlLayer.Reports;

namespace lab6.BlLayer
{
	public class Employee
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int Boss { get; set; }
		public List<Employee> SubordinateList { get; set; }
		public EmployeeType Type { get; set; }
		public Employee()
		{

		}
		public Employee(int id, string name,  List<Employee> subordinatelist, EmployeeType type)
		{
			ID = id;
			Name = name;
			SubordinateList = subordinatelist;
			Type = type;
		}
		public Employee(int id, string name, EmployeeType type)
		{
			ID = id;
			Name = name;
			Type = type;
		}
		public void ChangeSupervisor (int supervisorid)
		{
			Boss = supervisorid;
		}
		public void AddBoss(int supervisorid)
		{
			Boss = supervisorid;
		}
	}
}
