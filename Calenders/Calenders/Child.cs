using System;

namespace Calendars
{
    class Child
    {
        private string _name;
        private Date _birthdate;

        public Child(string name, Date birthdate)
        {
            _name = name;
            _birthdate = birthdate;
        }

        public Date GetDateByAge(int age) =>
            _birthdate.AddYears(age);

        public override string ToString() => 
            _name + " born on " + _birthdate;

        public Date GetFirstCelebrationAt(SchoolSystem school) =>
            school.GetBegining(this).GetFirstDayOccurence(_birthdate);
    }
}
