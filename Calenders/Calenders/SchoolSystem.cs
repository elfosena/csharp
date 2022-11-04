using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendars
{
    class SchoolSystem
    {
        private YearDate _cutoff;
        private int _minAge;
        private YearDate _schoolstart;

        public SchoolSystem(YearDate cutoff, int minAge, YearDate schoolstart)
        {
            _cutoff = cutoff;
            _minAge = minAge;
            _schoolstart = schoolstart;
        }   

        // expression bodied syntax
        public Date GetBegining(Child schoolchild) =>
            schoolchild
                .GetDateByAge(_minAge)
                .GetFirstOccurence(_cutoff)
                .GetFirstOccurence(_schoolstart);
    }
}
