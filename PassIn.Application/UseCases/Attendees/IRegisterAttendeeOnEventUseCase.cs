
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Attendees;
public interface IRegisterAttendeeOnEventUseCase
{
    public ResponseRegisteredJson Execute(Guid eventId, RequestRegisterEventJson request);
    public void Validate(Guid eventId, RequestRegisterEventJson request);
    public bool EmailIsValid(string email);

}
