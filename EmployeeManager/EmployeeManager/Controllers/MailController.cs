using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using EmployeeManager.Model;
using EmployeeManager.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public MailController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet("sendbirthdaymails")]
        public async Task<IActionResult> SendBirthdayMails()
        {
            int mailsSent = await _employeeService.SendBirthdayMails();
            if (mailsSent == 0)
            {
                return Ok("No birthdays to celebrate.");
            }
            return Ok("Sent " + mailsSent + " birthday mails.");
        }
    }
}
