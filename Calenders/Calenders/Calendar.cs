using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendars
{
    abstract class Calendar
    {
        public Date Create(int year, int month, int day) =>
            new Date(this, year, new YearDate(this, month, day));

        public YearDate Create(int month, int day) =>
            new YearDate(this, month, day);

        public abstract bool IsLeapYear(int year);

        public abstract String GetName();

        public bool IsLeapDay(int month, int day) => 
            month == 2 && day == 29;

        public int MaxDaysInMonth(int month) => 
            month == 2 ? 29
            : month == 4 || month == 6 || month == 9 || month == 11 ? 30
            : 31;

        public int NextMonth(int month) => 
            month % 12 + 1;

    }
}
