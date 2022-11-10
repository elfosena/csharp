using Calendars;

namespace Calenders
{
    internal class Program
    {
        static void Report(Child child, SchoolSystem school)
        {
            Console.WriteLine(
                child + " starts school on " + school.GetBegining(child) +
                ", celebrates on " + child.GetFirstCelebrationAt(school));
        }

        static void Report(Child[] children, SchoolSystem school)
        {
            for (int offset = 0; offset < children.Length; offset++)
            {
                Report(children[offset], school);
            }
        }

        static void Demonstrate(Calendar cal)
        {
            SchoolSystem school = new SchoolSystem(cal.Create(3, 1), 5, cal.Create(8, 15));

            Report(new Child[0], school);

            Child[] children = new Child[] {
                new Child("Jill", cal.Create(2008, 2, 29)),
                new Child("Jake", cal.Create(2007, 8, 27)),
                new Child("Jimmy", cal.Create(2008, 1, 31)),
                new Child("Jake", cal.Create(2009, 4, 22)),
                new Child("John", cal.Create(2010, 11, 14))
            };

            Console.WriteLine("Using " + cal.GetName() + " calendar:");
            Report(children, school);
            Console.WriteLine();
        }

        static void AddCalendars(List<Calendar> calendars)
        {
            calendars.Add(new JulianCalendar());
        }

        static void Main(string[] args)
        {
            List<Calendar> calenders = new List<Calendar>()
            {
                new GregorianCalendar()
            };
            AddCalendars(calenders);

            foreach (Calendar calender in calenders)
                Demonstrate(calender);

            Console.ReadLine();
        }
    }
}