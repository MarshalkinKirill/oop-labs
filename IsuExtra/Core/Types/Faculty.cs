using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Types
{
    public class Faculty
    {
        private string Name {  get; set; }
        private string cutName {  get; set; }
        public string CutName { get { return cutName; } }
        private List<ElectiveModule> electiveModules;
        public List<ElectiveModule> ElectiveModules { get { return electiveModules; } }

        public Faculty(string _name, string _cutName)
        {
            Name = _name;
            cutName = _cutName;
            electiveModules = new List<ElectiveModule>();
        }

        public void AddElectiveModule(String name,List<Flow> flows)
        {
            electiveModules.Add(new ElectiveModule(name, flows));
        }
    }
}
