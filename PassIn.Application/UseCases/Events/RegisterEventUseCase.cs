using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Domain.Entities.Events;
using PassIn.Exceptions;

namespace PassIn.Application.UseCases.Events;

public class RegisterEventUseCase : IRegisterEventUseCase
{
    private readonly IEventService _eventService;

    public RegisterEventUseCase(IEventService eventService)
    {
        _eventService = eventService;
    }

    public ResponseRegisteredJson Execute(RequestEventJson request)
    {
        Validate(request);

        var entity = new Event
        {
            Title = request.Title,
            Details = request.Details,
            Maximum_Attendees = request.MaximumAttendees,
            Id = Guid.NewGuid(),
            Slug = request.Title.ToLower().Replace(" ", "-")
        };

        _eventService.AddEvent(entity);

        return new ResponseRegisteredJson
        {
            Id = entity.Id,
        };
    }

    public void Validate(RequestEventJson request)
    {
        if (request.MaximumAttendees <= 0)
        {
            throw new ErrorOnValidationException("The Maximum attendees is invalid");
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ErrorOnValidationException("The title is invalid");
        }

        if (string.IsNullOrWhiteSpace(request.Details))
        {
            throw new ErrorOnValidationException("The details are invalid");
        }
    }
}
