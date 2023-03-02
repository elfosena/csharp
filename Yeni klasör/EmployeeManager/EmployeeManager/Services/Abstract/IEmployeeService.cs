using EmployeeManager.Model;
using Microsoft.Extensions.Hosting;

namespace EmployeeManager.Services.Abstract
{
    public interface IEmployeeService
    {
        Employee Get(int id);
        List<Employee> GetAll();
        List<Employee> GetByBirthdate(DateTime birthdate);
        void Create(Employee entity);
        void Delete(Employee entity);
        void Update(Employee entity);
        Task<int> SendBirthdayMails();
    }
}
