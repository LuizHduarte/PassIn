namespace PassIn.Domain.Entities.Attendees;
public interface IAttendeeService
{
    void AddAttendeeOnEvent(Attendee attendee);
    bool CheckAttendeeAlreadyRegisterd(string email, Guid eventId);
}
