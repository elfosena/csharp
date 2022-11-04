using Calendars;

namespace Calenders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Date birthdate = new Date(2016, new YearDate(2, 29));
            Child schoolchild = new Child("Jill", birthdate);

            SchoolSystem school = 
                new SchoolSystem(new YearDate(3, 1), 5, new YearDate(8, 15));
            Date schoolStart = school.GetBegining(schoolchild);

            Console.WriteLine(birthdate);
            Console.WriteLine(schoolchild);
            Console.WriteLine(schoolStart);
            Console.ReadLine();
        }
    }
}