using System;
using System.Collections.Generic;
using System.Text;

namespace lab6.BlLayer
{
	public class TaskSystem
	{
		List<Task> TaskSystemList = new List<Task>();
		public TaskSystem(List<Task> tasksystemlist)
		{
			TaskSystemList = tasksystemlist;
		}
		public Task SearchTaskByID (int id) //+
		{
			var ourtask = TaskSystemList.Find(item => item.TaskID == (id));
			return ourtask;
		}
		public Task SearchTaskByCreationDate (DateTime time) //+
		{
			var ourtask = TaskSystemList.Find(item => item.CreationTime.Equals(time));
			return ourtask;
		}
		public Task SearchTaskByChangeDate (DateTime time)
		{
			var ourtask = TaskSystemList.Find(item => item.LastChangeDate.Equals(time));
			return ourtask;
		}
		public List<Task> SearchTaskByImplementer (int implementerid) //+
		{
			List<Task> ourlist = new List<Task>();
			foreach (Task task in TaskSystemList)
			{
				if (task.ImplementerID == implementerid)
				{
					ourlist.Add(task);
				}
			}
			return ourlist;
		}
		public List<Task> SearchChangedTasks() //+
		{
			List<Task> ourlist = new List<Task>();
			foreach (Task task in TaskSystemList)
			{
				if(task.TaskChanges.Count > 0)
				{
					ourlist.Add(task);
				}
			}
			return ourlist;
		}
		public Task CreateTask (int id, int sprintid, string name, string description, int reporterid) //+
		{
			Task task = new Task(id, sprintid, name, description, reporterid);
			TaskSystemList.Add(task);
			return task;
		}
		public void ChangeTaskStatus (int taskid, TaskStatus status, int employee) //+
		{
			var task = TaskSystemList.Find(item => item.TaskID == (taskid));
			task.Status = status;
			if(status == TaskStatus.Resolved)
			{
				task.ResolvedTime = DateTime.Now;
				TaskChange newchange = new TaskChange(task.TaskID, employee, OperationType.NewTaskStatus);
				newchange.SetStatus(TaskStatus.Resolved);
				task.TaskChanges.Add(newchange);
			}
			TaskChange newchange1 = new TaskChange(task.TaskID, employee, OperationType.NewTaskStatus);
			newchange1.SetStatus(status);
			task.TaskChanges.Add(newchange1);
		}
		public void AddCommentToTask(int taskid, int commentid, int commentatorid) //+
		{
			var task = TaskSystemList.Find(item => item.TaskID == (taskid));
			task.AddComment(commentid, commentatorid);
		}
		public void ChangeTaskImplementer(int taskid, int newimplementerid, int employeewhoappoint) //+
		{
			var task = TaskSystemList.Find(item => item.TaskID == (taskid));
			task.ChangeImplementer(newimplementerid, employeewhoappoint);
		}
		public void AppointTaskImplementer (int taskid, int implementerid, int employeewhoappoint) //+
		{
			var task = TaskSystemList.Find(item => item.TaskID == (taskid));
			task.AppointImplementer(implementerid, employeewhoappoint);
		}
		public List<Task> GetSubordinatesTasks (Employee supervisor) //+
		{
			List<Task> ourlist = new List<Task>();
			foreach(Employee subordinate in supervisor.SubordinateList)
			{
				foreach(Task task in TaskSystemList)
				{
					if(task.ImplementerID == subordinate.ID)
					{
						ourlist.Add(task);
					}
				}
			}
			return ourlist;
		}
	}
}
