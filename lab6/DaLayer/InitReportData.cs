using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using lab6.BlLayer.Reports;

namespace lab6.DaLayer
{
    public class InitReportData
    {
		private string ReportPath;
		private List<AReport> ReportData;
		public InitReportData(string path)
		{
			ReportPath = path;
			ReportData = new List<AReport>();
			InitFile(path);
			SaveReport(ReportData, path);
		}
		private void InitFile(string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		public void SaveReport(List<AReport> reports, string path)
		{

			File.AppendAllText(path, JsonSerializer.Serialize(reports));
		}
		public void AddReport(AReport report)
		{
			InitFile(ReportPath);
			ReportData.Add(report);
			SaveReport(ReportData, ReportPath);
		}
	}
}
