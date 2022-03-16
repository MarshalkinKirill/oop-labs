using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Text;
using lab6.BlLayer.Reports;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace lab6.DaLayer
{
    public class ReadReportData
    {
		public List<AReport> ReadReportsData(string path)
		{
			List<AReport> reportlist = new List<AReport>();
			reportlist = JsonSerializer.Deserialize<List<AReport>>(File.ReadAllText(path));
			return reportlist;
		}
	}
}
