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


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PassInDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("pgsqlConnection")));
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
