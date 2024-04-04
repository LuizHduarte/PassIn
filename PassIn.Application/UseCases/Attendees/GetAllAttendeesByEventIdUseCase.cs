using PassIn.Communication.Responses;
using PassIn.Domain.Entities.Attendees;
using PassIn.Exceptions;

namespace PassIn.Application.UseCases.Attendees;
public class GetAllAttendeesByEventIduseCase : IGetAllAttendeesByEventIdUseCase
{
    private readonly IAttendeeService _attendeeService;
    public GetAllAttendeesByEventIduseCase(IAttendeeService attendeeService)
    {
        _attendeeService = attendeeService;
    }

    public ResponseAllAttendeesJson Execute(Guid eventId)
    {
        var response = _attendeeService.GetAllAttendees(eventId);

        if(response is null)
        {
            throw new NotFoundException("An event with this id does not exists");
        }

        return response;
    }
}
