using PassIn.Domain.Entities.Attendees;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassIn.Domain.Entities.Checkin;
public class CheckIn
{
    public Guid Id { get; set; }
    public DateTime Created_at { get; set; }
    public Guid Attendee_Id { get; set; }
    [ForeignKey("Attendee_Id")]
    public Attendee Attendee { get; set; } = default!;

}
