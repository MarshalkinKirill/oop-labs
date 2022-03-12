using System;
using System.Collections.Generic;
using System.Text;

namespace lab6.BlLayer
{
	public class Comment
	{
		public int ID { get; set; }
		public int EmployeeID { get; set; }
		public string Text { get; set; }
		public Comment()
		{

		}
		public Comment (int id, int employeeid, string text)
		{
			ID = id;
			EmployeeID = employeeid;
			Text = text;
		}
	}
}
