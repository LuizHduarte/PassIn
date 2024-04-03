using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Checkin;
public interface IAttendeeCheckinUseCase
{
    public ResponseRegisteredJson Execute(Guid attendeeId);
}
