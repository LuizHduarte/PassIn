using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Domain.Entities.Attendees;
using PassIn.Domain.Entities.Events;

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

    public ResponseAllAttendeesJson GetAllAttendees(Guid eventId)
    {
        var response = _dbContext.Events
            .Include(ev => ev.Attendees)
            .FirstOrDefault(ev => ev.Id == eventId);

        return new ResponseAllAttendeesJson
        {
            Attendees = response.Attendees.Select(attendee => new ResponseAttendeeJson
            {
                Id = attendee.Id,
                Name = attendee.Name,
                Email = attendee.email,
                CreatedAt = attendee.Created_At
            }).ToList()
        };
    }
}
