namespace Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Birthdate: ");
            if (int.TryParse(Console.ReadLine(), out int birthdate))
            {
                SchoolCalender cal1 = new SchoolCalender(6, 9, 1);
                SchoolCalender cal2 = new JulianSchoolCalendar(6, 9, 1);

                Console.WriteLine(cal1.FirstDayOfSchool(birthdate));
                Console.WriteLine(cal2.FirstDayOfSchool(birthdate));
                Console.WriteLine(cal1.FirstBirthdayAtSchool(birthdate));
                Console.WriteLine(cal2.FirstBirthdayAtSchool(birthdate));
            }

        }
    }

    class SchoolCalender
    {
        private int age;
        private int month;
        private int day;

        public SchoolCalender(int age, int month, int day)
        {
            this.month = month;
            this.day = day;
            this.age = age;
        }

        public virtual bool isLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        public int FirstDayOfSchool(int birthdate)
        {
            int birthyear = birthdate / 10000;
            int birthmonth = (birthdate % 1000) / 100;
            int birthday = (birthdate % 100000);
            int year = birthyear + age;

            if (birthmonth < month && (birthmonth == month && birthday <= day))
            {
                year++;
            }

            return year * 10000 + month * 100 + day;
        }

        public int FirstBirthdayAtSchool(int birthdate)
        {
            int schoolstart = FirstDayOfSchool(birthdate);
            int year = schoolstart / 10000;

            if (birthdate % 10000 == 229)
            {
                while (!isLeapYear(year))
                {
                    year++;
                }
            }
            return year * 10000 + (birthdate % 10000);
        }
    }

    class JulianSchoolCalendar : SchoolCalender
    {
        public JulianSchoolCalendar(int age, int month, int day) : base(age, month, day)
        {

        }

        public override bool isLeapYear(int year)
        {
            return year % 4 == 0;
        }

    }
}