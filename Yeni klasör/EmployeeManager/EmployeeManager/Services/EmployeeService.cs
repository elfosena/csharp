using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using EmployeeManager.Model;
using EmployeeManager.Repositories;
using EmployeeManager.Repositories.Abstract;
using EmployeeManager.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EmployeeManager.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository = new EmployeeRepository();
        string mailUrl = "https://localhost:7266/api/";
        IDictionary<string, string> credentials = new Dictionary<string, string>()
        {
            {"username", "employeemanager"},
            {"password", "employeemanager"},
            {"confirmPassword", "employeemanager"}
        };

        public void Create(Employee entity)
        {
            _employeeRepository.Create(entity);
        }

        public void Delete(Employee entity)
        {
            _employeeRepository.Delete(entity);
        }

        public Employee Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public List<Employee> GetByBirthdate(DateTime birthdate)
        {
            return _employeeRepository.GetByBirthdate(birthdate);
        }

        public void Update(Employee entity)
        {
            _employeeRepository.Update(entity);    
        }

        public async Task<int> SendBirthdayMails()
        {
            DateTime today = DateTime.Today;
            var employees = GetByBirthdate(today);
            if (employees.Count != 0)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(mailUrl);

                    var credentialContent = new StringContent(JsonSerializer.Serialize(credentials), Encoding.UTF8, "application/json");
                    var registerResponse = await httpClient.PostAsync("Auth/register", credentialContent);
                    registerResponse.EnsureSuccessStatusCode();

                    var loginResponse = await httpClient.PostAsync("Auth/login", credentialContent);
                    var json = JObject.Parse(await loginResponse.Content.ReadAsStringAsync());
                    string token = json.GetValue("token").ToString();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "multipart/form-data");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    foreach (var employee in employees)
                    {
                        var formContent = new MultipartFormDataContent
                    {
                        {new StringContent(employee.Email), "Reciever"},
                        {new StringContent("Happy Birthday!"), "Subject"},
                        {new StringContent("Happy Birthday " + employee.FullName + "!"), "Body"},
                    };
                        var mailResponse = await httpClient.PostAsync("Email/send", formContent);
                        mailResponse.EnsureSuccessStatusCode();
                    }

                    return employees.Count();
                }
            }
            return 0;
        }
    }
}
