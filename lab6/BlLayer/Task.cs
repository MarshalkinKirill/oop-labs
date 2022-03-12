using System;
using System.Collections.Generic;
using System.Text;
using lab6.DaLayer;

namespace lab6.BlLayer
{
	public class Task
	{
		public int TaskID { get; set; }
		public int SprintID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreationTime { get; set; }
		public DateTime ResolvedTime { get; set; }
		public int ReporterID { get; set; }
		public int? ImplementerID { get; set; }
		public TaskStatus Status { get; set; }
		public DateTime LastChangeDate { get; set; }
		public List<int> CommentList { get; set; }
		public List<TaskChange> TaskChanges { get; set; }
		public Task()
		{

		}
		public Task(Task task)
		{
			TaskID = task.TaskID;
			SprintID = task.SprintID;
			Name = task.Name;
			Description = task.Description;
			CreationTime = task.CreationTime;
			ResolvedTime = task.ResolvedTime;
			ReporterID = task.ReporterID;
			ImplementerID = task.ImplementerID;
			Status = task.Status;
			CommentList = task.CommentList;
			TaskChanges = task.TaskChanges;
		}
		public Task (int id, int sprintid, string name, string description, int reporterid)
		{
			TaskID = id;
			SprintID = sprintid;
			Name = name;
			Description = description;
			CreationTime = DateTime.Now.Date;
			ReporterID = reporterid;
			ImplementerID = null;
			Status = TaskStatus.Open;
			CommentList = new List<int>();
			TaskChanges = new List<TaskChange>();
		}
		public void AppointImplementer(int implementerid, int employeewhoappoint)
		{
			LastChangeDate = DateTime.Now.Date;
			ImplementerID = implementerid;
			Status = TaskStatus.Active;
			TaskChange newchange = new TaskChange(TaskID, employeewhoappoint, OperationType.NewImplementer);
			newchange.SetStatus(TaskStatus.Active);
			newchange.SetNewImplementerID(implementerid);
			TaskChanges.Add(newchange);
			
		}
		public void ChangeImplementer(int newimplementerid, int employeewhoappoint)
		{
			LastChangeDate = DateTime.Now.Date;
			ImplementerID = newimplementerid;
			TaskChange newchange = new TaskChange(TaskID, employeewhoappoint, OperationType.NewImplementer);
			newchange.SetNewImplementerID(newimplementerid);
			TaskChanges.Add(newchange);
		}
		public void AddComment (int commentid, int comentatorid)
		{
			LastChangeDate = DateTime.Now.Date;
			CommentList.Add(commentid);
			TaskChange newchange = new TaskChange(TaskID, comentatorid, OperationType.NewComment);
			newchange.SetNewCommentID(commentid);
			TaskChanges.Add(newchange);
		}
		public void CloseTask(int closerid)
		{
			LastChangeDate = DateTime.Now.Date;
			ResolvedTime = DateTime.Now.Date;
			Status = TaskStatus.Resolved;
			TaskChange newchange = new TaskChange(TaskID, closerid, OperationType.NewTaskStatus);
			newchange.SetStatus(TaskStatus.Resolved);
			TaskChanges.Add(newchange);
		}

	}
}
