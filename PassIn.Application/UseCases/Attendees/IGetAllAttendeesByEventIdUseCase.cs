using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Attendees;
public interface IGetAllAttendeesByEventIdUseCase
{
    public ResponseAllAttendeesJson Execute(Guid eventId);
}
