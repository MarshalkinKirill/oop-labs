using System;
using System.Collections.Generic;
using System.Text;
using BackupsExtra.Core.Abstructions;
using Backups.Core.SystemObjects.Types;
using BackupsExtra.Core.SystemObjects.Types;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BackupsExtra.Core.SystemObjects.Types
{
    public class StateRestoringSystem
    {
        private string restorePointsPath { get; set; }
        private List<RestorePoint> restorePoints { get; set; }

        public StateRestoringSystem(string _restorePointsPath, List<RestorePoint> _restorePoint)
        {
            restorePointsPath = _restorePointsPath;
            restorePoints = _restorePoint;
        }

        private void InitFile()
        {
            if (File.Exists(restorePointsPath))
            {
                File.Delete(restorePointsPath);
            }
        }

        public void SaveRestorePoints()
        {
            InitFile();
            File.AppendAllText(restorePointsPath, JsonSerializer.Serialize(restorePoints));
        }

        public List<RestorePoint> StateRestorePoints()
        {
            restorePoints = JsonSerializer.Deserialize<List<RestorePoint>>(File.ReadAllText(restorePointsPath));
            return restorePoints;
        }
    }
}
