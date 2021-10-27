using System;
using System.Collections.Generic;
using System.Text;
using Isu.Services.Types;
using Isu.Services;

namespace IsuExtra.Core.Types
{
    public class ElectiveModule
    {
        public string Name {  get; set; }
        private List<Flow> flows {  get; set; }
        public List<Flow> Flows {  get {  return flows; } }

        public ElectiveModule(string _name, List<Flow> _flows)
        {
            Name = _name;
            flows = _flows;
        }

        public ElectiveModule(string _name)
        {
            Name = _name;
            flows = new List<Flow>();
        }

        public void AddFlow(int _places, Schadule _schadule)
        {
            flows.Add(new Flow(_places, _schadule));
        }

        public void AddStudent(Student _student, Flow _flow)
        {
            _flow.AddStudent(_student);

        }
    }
}
