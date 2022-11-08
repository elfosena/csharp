using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendars
{
    class Date
    {
        private int _year;
        private YearDate _day;
        private Calendar _calendar;

        public Date(Calendar calendar, int year, YearDate day)
        {
            _calendar = calendar;   
            _year = year;
            _day = day;
        }

        public Date AddYears(int year) =>
            FirstValidDate(_year + year, _day);

        private Date FirstValidDate(int year, YearDate day) =>
            new Date(_calendar, year, day.IsLeap() && !_calendar.IsLeapYear(year) ? day.GetNext() : day);

        public Date GetFirstOccurence(YearDate day) =>
            GetFirstDayOccurence(day.IsBefore(_day) ? _year + 1 : _year, day);

        private Date GetFirstDayOccurence(int year, YearDate day) =>
            new Date(_calendar, day.IsLeap() ? GetLeap(year) : year, day);

        private int GetLeap(int year) =>
            _calendar.IsLeapYear(year) ? year : GetLeap(year + 1);

        public Date GetFirstDayOccurence(Date day) =>
            GetFirstDayOccurence(_year, day._day);

        public override string ToString()
        {
            return _day + "/" + _year;
        }
    }
}
