using PassIn.Domain.Entities.Attendees;

namespace PassIn.Infrastructure.AttendeeService;
public class AttendeeService : IAttendeeService
{
    private readonly PassInDbContext _dbContext;
    public AttendeeService()
    {
        _dbContext = new PassInDbContext();
    }

    public void AddAttendeeOnEvent(Attendee attendee)
    {
        _dbContext.Attendees.Add(attendee);
        _dbContext.SaveChanges();
    }

    public bool CheckAttendeeAlreadyRegisterd(string email, Guid eventId)
    {
        return _dbContext
            .Attendees
            .Any(attendee => attendee.email.Equals(email) && attendee.Event_Id == eventId);
    }

  
}
