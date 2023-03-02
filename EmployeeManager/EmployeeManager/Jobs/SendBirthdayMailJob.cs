using EmployeeManager.Services.Abstract;
using Quartz;

namespace EmployeeManager.Jobs
{
    [DisallowConcurrentExecution]
    public class SendBirthdayMailJob : IJob
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<SendBirthdayMailJob> _logger;

        public SendBirthdayMailJob(IEmployeeService employeeService, ILogger<SendBirthdayMailJob> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Starting to send birthday mails.");
            var mailsSent = await _employeeService.SendBirthdayMails();
            _logger.LogInformation("Sent {0} birthday mails", mailsSent.ToString());
        }
    }
}
