namespace PassIn.Domain.Entities.Events;
public interface IEventService
{
    void AddEvent(Event newEvent);
    Event FindEventById(Guid id);
    public int CountEventRegisters(Guid eventId);
}
