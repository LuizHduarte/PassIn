using Microsoft.EntityFrameworkCore;
using PassIn.Api.Filters;
using PassIn.Application.UseCases.Attendees;
using PassIn.Application.UseCases.Checkin;
using PassIn.Application.UseCases.Events;
using PassIn.Domain.Entities.Attendees;
using PassIn.Domain.Entities.Checkin;
using PassIn.Domain.Entities.Events;
using PassIn.Infra;
using PassIn.Infra.AttendeeService;
using PassIn.Infra.CheckinService;
using PassIn.Infra.Service;
using System.IO;


var builder = WebApplication.CreateBuilder(args);

/*
var str_directory = Environment.CurrentDirectory.ToString();
var root = Directory.GetParent(str_directory).FullName;
var dotenv = Path.Combine(root, ".env");
DotEnvService.Load(dotenv);
*/

var POSTGRES_USER = Environment.GetEnvironmentVariable("POSTGRES_USER");
Console.WriteLine(POSTGRES_USER);
var POSTGRES_PASSWORD = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
var POSTGRES_DB = Environment.GetEnvironmentVariable("POSTGRES_DB");
var POSTGRES_SERVER = Environment.GetEnvironmentVariable("POSTGRES_SERVER");
var connectionString = $"Server={POSTGRES_SERVER};Database=passin;User Id={POSTGRES_USER};Password={POSTGRES_PASSWORD};Pooling=true";

builder.Configuration["DbConnectionString"] = connectionString;
builder.Services.AddDbContext<PassInDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PassIn API", Version = "v1" });
} );

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddScoped<IRegisterAttendeeOnEventUseCase, RegisterAttendeeOnEventUseCase>();
builder.Services.AddScoped<IGetEventByIdUseCase, GetEventByIdUseCase>();
builder.Services.AddScoped<IRegisterEventUseCase, RegisterEventUseCase>();
builder.Services.AddScoped<IGetAllAttendeesByEventIdUseCase, GetAllAttendeesByEventIduseCase>();
builder.Services.AddScoped<IAttendeeCheckinUseCase, AttendeeCheckinUseCase>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IAttendeeService, AttendeeService>();
builder.Services.AddScoped<ICheckinService, CheckinService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
