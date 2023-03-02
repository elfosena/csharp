using EmployeeManager.Model;
using EmployeeManager.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Json;

namespace EmployeeManager.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeContext db = new EmployeeContext();

        public void Create(Employee entity)
        {
            db.Employees.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            db.Employees.Remove(entity);
            db.SaveChanges();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }


        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public List<Employee> GetByBirthdate(DateTime birthdate)
        {
            return db.Employees.Where(i => (i.Birthdate.Day == birthdate.Day && i.Birthdate.Month == birthdate.Month))
                                .ToList();
        }

        public void Update(Employee entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
