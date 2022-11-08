using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendars
{
    class GregorianCalendar : Calendar
    {
        public override string GetName() =>
            "Gregorian";

        public override bool IsLeapYear(int year) =>
            year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
    }
}
