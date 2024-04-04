using PassIn.Domain.Entities.Checkin;

namespace PassIn.Domain.Entities.Attendees;
public class Attendee
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid Event_Id { get; set; }
    public DateTime Created_At { get; set; }
    public CheckIn? CheckIn { get; set; }
}
