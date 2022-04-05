using System;
using System.Collections.Generic;
using System.Text;
using lab6.BlLayer.Reports;

namespace lab6.BlLayer
{
	public class Sprint
	{
		public int ID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public Sprint()
		{

		}
		public Sprint (int id, DateTime startdate, DateTime enddate)
		{
			ID = id;
			StartDate = startdate;
			EndDate = enddate;
		}
	}
}
