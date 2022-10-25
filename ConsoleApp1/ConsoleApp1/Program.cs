namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Birthdate: ");
            if (int.TryParse(Console.ReadLine(), out int birthdate))
            {
                SchoolCalender cal = new SchoolCalender(6, 9, 1);
                SchoolCalender cal2 = new SchoolCalender(5, 9, 1);

                Console.WriteLine(cal.FirstDayOfSchool(birthdate));
                Console.WriteLine(cal2.FirstDayOfSchool(birthdate));
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
            int birthday = (schoolstart / 10000) * 10000 + birthdate % 10000;

            if (birthdate % 10000 / 100 == 2 || birthdate % 100000)
            {
                
            }
        }



    }
}