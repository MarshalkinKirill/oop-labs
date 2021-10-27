using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Types
{
    public class Schadule
    {
        private List<Class> classes {  get; set; }
        public List<Class> Classes { get { return classes; } }
        public Schadule()
        {
            List<Class> classes = new List<Class>();
        }

        public Schadule(List<Class> _classes)
        {
            classes = _classes;
        }

        public void AddClasses(List<Class> _classes)
        {
            classes = _classes;
        }
    }
}
