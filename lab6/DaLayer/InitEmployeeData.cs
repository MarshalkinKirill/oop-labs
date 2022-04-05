using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using lab6.BlLayer;

namespace lab6.DaLayer
{
	public class InitEmployeeData
	{
		private string EmployeePath;
		private List<Employee> EmployeeDataList;
		public InitEmployeeData(string path)
		{
			EmployeePath = path;
			EmployeeDataList = new List<Employee>();
			InitFile(path);
			EmployeeDataList.Add(new Employee(1, "Denis", EmployeeType.TeamLeader));
			EmployeeDataList.Add(new Employee(2, "Anatoly", EmployeeType.BaseEmployee));
			EmployeeDataList.Add(new Employee(3, "Kirill", EmployeeType.BaseEmployee));
			EmployeeDataList.Add(new Employee(4, "Sasha", EmployeeType.SuperVisor));
			EmployeeDataList.Add(new Employee(5, "Danya", EmployeeType.BaseEmployee));
			SaveEmployees(EmployeeDataList, path);
		}
		private void InitFile(string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		public void SaveEmployees(List<Employee> employees, string path)
		{

			File.AppendAllText(path, JsonSerializer.Serialize(employees));
		}
		public void AddEmployee(Employee employee)
		{
			InitFile(EmployeePath);
			EmployeeDataList.Add(employee);
			Console.WriteLine(EmployeeDataList.Count);
			SaveEmployees(EmployeeDataList, EmployeePath);
		}
		public void UpdateEmployee(int id, Employee changes)
		{
			var changedemployee = EmployeeDataList.Find(item => item.ID == (id));
			EmployeeDataList.Remove(changedemployee);
			EmployeeDataList.Add(changes);
			InitFile(EmployeePath);
			SaveEmployees(EmployeeDataList, EmployeePath);
		}

		public int GetCount()
        {
			Console.WriteLine(EmployeeDataList.Count);
			return EmployeeDataList.Count;
        }

	}
}