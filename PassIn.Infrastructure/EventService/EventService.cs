using Microsoft.EntityFrameworkCore;
using PassIn.Domain.Entities.Events;

namespace PassIn.Infrastructure.EventService;
public class EventService : IEventService
{
    private readonly PassInDbContext _dbContext;

    public EventService()
    {
        _dbContext = new PassInDbContext();
    }

    public void AddEvent(Event entity)
    {
        _dbContext.Events.Add(entity);
        _dbContext.SaveChanges();
    }

    public Event FindEventById(Guid id)
    {
        //dbContext.Events.Find(id);
        var entity = _dbContext.Events.Include(ev => ev.Attendees).FirstOrDefault(ev => ev.Id == id);
        return entity;
    }

    public int CountEventRegisters(Guid eventId)
    {
        return _dbContext.Attendees.Count(attendee => attendee.Event_Id == eventId);
    }
}
