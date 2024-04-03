using PassIn.Communication.Responses;

namespace PassIn.Domain.Entities.Attendees;
public interface IAttendeeService
{
    void AddAttendeeOnEvent(Attendee attendee);
    bool CheckAttendeeAlreadyRegisterd(string email, Guid eventId);
    public ResponseAllAttendeesJson GetAllAttendees(Guid eventId);
    public bool CheckExistingAttendee(Guid attendeeId);
}
