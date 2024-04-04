using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Domain.Entities.Attendees;

namespace PassIn.Infra.AttendeeService;
public class AttendeeService : IAttendeeService
{
    private readonly PassInDbContext _dbContext;
    public AttendeeService(PassInDbContext dbContext)
    {
        _dbContext = dbContext;
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
            .Any(attendee => attendee.Email.Equals(email) && attendee.Event_Id == eventId);
    }

    public ResponseAllAttendeesJson GetAllAttendees(Guid eventId)
    {

        var response = _dbContext.Events
            .Include(ev => ev.Attendees)
            .ThenInclude(attendee => attendee.CheckIn)
            .FirstOrDefault(ev => ev.Id == eventId);

        if (response is null)
        {
            return new ResponseAllAttendeesJson();
        }

        return new ResponseAllAttendeesJson
        {
            Attendees = response.Attendees.Select(attendee => new ResponseAttendeeJson
            {
                Id = attendee.Id,
                Name = attendee.Name,
                Email = attendee.Email,
                CreatedAt = attendee.Created_At,
                CheckedInAt = attendee.CheckIn?.Created_at

            }).ToList()
        };
    }

    public bool CheckExistingAttendee(Guid attendeeId)
    {
        return _dbContext.Attendees.Any(attendee => attendee.Id == attendeeId);
    }
}
