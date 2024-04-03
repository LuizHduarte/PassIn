using PassIn.Api.Filters;
using PassIn.Application.UseCases.Attendees;
using PassIn.Application.UseCases.Events;
using PassIn.Domain.Entities.Attendees;
using PassIn.Domain.Entities.Events;
using PassIn.Infrastructure.AttendeeService;
using PassIn.Infrastructure.EventService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRegisterAttendeeOnEventUseCase, RegisterAttendeeOnEventUseCase>();
builder.Services.AddScoped<IGetEventByIdUseCase, GetEventByIdUseCase>();
builder.Services.AddScoped<IRegisterEventUseCase, RegisterEventUseCase>();
builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddScoped<IEventService>(options =>
{
    return new EventService();
});
builder.Services.AddScoped<IAttendeeService>(options =>
{
    return new AttendeeService();
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
