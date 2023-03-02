using EmployeeManager.Jobs;
using EmployeeManager.Services;
using EmployeeManager.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.Configure<ApiBehaviorOptions>(options
                                    => options.SuppressModelStateInvalidFilter = true);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();

    var jobKey = new JobKey("SendBirthdayMailJob");

    q.AddJob<SendBirthdayMailJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity($"{jobKey}-trigger")
        .WithCronSchedule(builder.Configuration.GetSection("SendBirthdayMailJobSettings:CronSchedule").Value ?? "0 0 10 1/1 * ? *")); //Her gün sabah 10da
});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
