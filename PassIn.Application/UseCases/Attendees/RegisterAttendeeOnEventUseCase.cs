using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Domain.Entities.Attendees;
using PassIn.Domain.Entities.Events;
using PassIn.Exceptions;
using System.Net.Mail;

namespace PassIn.Application.UseCases.Attendees;
public class RegisterAttendeeOnEventUseCase : IRegisterAttendeeOnEventUseCase
{
    private readonly IAttendeeService _attendeeService;
    private readonly IEventService _eventService;

    public RegisterAttendeeOnEventUseCase(IAttendeeService attendeeService, IEventService eventService)
    {
        _attendeeService = attendeeService;
        _eventService = eventService;
    }

    public ResponseRegisteredJson Execute(Guid eventId, RequestRegisterEventJson request)
    {
        Validate(eventId, request);

        var entity = new Attendee
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Name = request.Name,
            Event_Id = eventId,
            Created_At = DateTime.UtcNow,
        };

        _attendeeService.AddAttendeeOnEvent(entity);

        return new ResponseRegisteredJson
        {
            Id = entity.Id
        };
    }

    public void Validate(Guid eventId, RequestRegisterEventJson request)
    {
        
        var eventEntity = _eventService.FindEventById(eventId);

        if (eventEntity is null)
        {
            throw new NotFoundException("An event with this id does not exist");
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ErrorOnValidationException("The name is invalid");
        }

        var emailIsValid = EmailIsValid(request.Email);
        if (emailIsValid == false)
        {
            throw new ErrorOnValidationException("The email is invalid");
        }

        var attendeeAlreadyRegisterd = _attendeeService.CheckAttendeeAlreadyRegisterd(request.Email, eventId);
        if (attendeeAlreadyRegisterd)
        {
            throw new ConflitException("You can not register twice on the same event.");
        }

        var attendeesForEvent = _eventService.CountEventRegisters(eventId);

        if (attendeesForEvent >= eventEntity.Maximum_Attendees)
        {
            throw new ConflitException("There is no room for this event.");
        }
    }

    public bool EmailIsValid(string email)
    {
        try
        {
            new MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }

    }
}
