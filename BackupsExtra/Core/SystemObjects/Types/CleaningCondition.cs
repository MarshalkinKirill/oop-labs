using System;
using System.Collections.Generic;
using System.Text;

namespace BackupsExtra.Core.SystemObjects.Types
{
    public class CleaningCondition
    {
        private DateTime time { get; }
        public DateTime Time { get { return time; } }
        private int counter { get; } = 0;
        public int Counter { get { return counter; } }

        public CleaningCondition(DateTime _time, int _counter)
        {
            time = _time;
            counter = _counter;
        }

        public CleaningCondition(DateTime _time)
        {
            time = _time;
        }

        public CleaningCondition(int _counter)
        {
            counter = _counter;
        }

    }
}
