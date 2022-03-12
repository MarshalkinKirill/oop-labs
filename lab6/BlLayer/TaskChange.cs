using System;
using System.Collections.Generic;
using System.Text;
using lab6.BlLayer;

namespace lab6.BlLayer
{
	public class TaskChange
	{
		public DateTime ChangeDay { get; set; }
		public int TaskID { get; set; }
		public int EmployeeID { get; set; } 
		public OperationType TypeOfChange { get; set; }
		public TaskStatus? NewTaskStatus { get; set; }
		public int? NewImplementerID { get; set; }
		public int? NewCommentID { get; set; }
		public TaskChange()
		{

		}
		public TaskChange(int taskid, int employeeid, OperationType typeofchange )
		{
			ChangeDay = DateTime.Now.Date;
			TaskID = taskid;
			EmployeeID = employeeid;
			TypeOfChange = typeofchange;
		}
		public void SetStatus(TaskStatus newstatus)
		{
			NewTaskStatus = newstatus;
		}
		public void SetNewImplementerID(int id)
		{
			NewImplementerID = id;
		}
		public void SetNewCommentID(int id)
		{
			NewCommentID = id;
		}
	}
}
