using PassIn.Api.Filters;
using PassIn.Application.UseCases.Attendees;
using PassIn.Application.UseCases.Checkin;
using PassIn.Application.UseCases.Events;
using PassIn.Domain.Entities.Attendees;
using PassIn.Domain.Entities.Checkin;
using PassIn.Domain.Entities.Events;
using PassIn.Infrastructure.AttendeeService;
using PassIn.Infrastructure.CheckinService;
using PassIn.Infrastructure.EventService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IRegisterAttendeeOnEventUseCase, RegisterAttendeeOnEventUseCase>();
builder.Services.AddScoped<IGetEventByIdUseCase, GetEventByIdUseCase>();
builder.Services.AddScoped<IRegisterEventUseCase, RegisterEventUseCase>();
builder.Services.AddScoped<IGetAllAttendeesByEventIdUseCase, GetAllAttendeesByEventIduseCase>();
builder.Services.AddScoped<IAttendeeCheckinUseCase, AttendeeCheckinUseCase>();
builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddScoped<IEventService>(options =>
{
    return new EventService();
});
builder.Services.AddScoped<IAttendeeService>(options =>
{
    return new AttendeeService();
});
builder.Services.AddScoped<ICheckinService>(options =>
{
    return new CheckinService();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
