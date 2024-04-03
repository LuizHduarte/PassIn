using PassIn.Communication.Responses;
using PassIn.Domain.Entities.Attendees;
using PassIn.Domain.Entities.Checkin;
using PassIn.Exceptions;

namespace PassIn.Application.UseCases.Checkin;
public class AttendeeCheckinUseCase : IAttendeeCheckinUseCase
{
    private readonly IAttendeeService _attendeeService;
    private readonly ICheckinService _checkinService;

    public AttendeeCheckinUseCase(IAttendeeService attendeeService, ICheckinService checkinService)
    {
        _attendeeService = attendeeService;
        _checkinService = checkinService;
    }

    public ResponseRegisteredJson Execute(Guid attendeeId)
    {
        Validate(attendeeId);

        var entity = new CheckIn
        {
            Id = Guid.NewGuid(),
            Attendee_Id = attendeeId,
            Created_at = DateTime.UtcNow,

        };

        _checkinService.DoAttendeeCheckin(entity);

        return new ResponseRegisteredJson()
        {
            Id = entity.Id,
        };
    }

    public void Validate(Guid attendeeId)
    {
        var existAttendee = _attendeeService.CheckExistingAttendee(attendeeId);
        if (existAttendee == false)
        {
            throw new NotFoundException("The attendee with this ID was not found");
        }

        var existCheckin = _checkinService.CheckAllReadyCheckedAttendee(attendeeId);
        if(existCheckin)
        {
            throw new ConflitException("Attendee can not do checking twice in the same event"); 
        }
    }
}
