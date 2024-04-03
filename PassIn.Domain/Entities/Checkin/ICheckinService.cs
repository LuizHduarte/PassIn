namespace PassIn.Domain.Entities.Checkin;
public interface ICheckinService
{
    public void DoAttendeeCheckin(CheckIn checkIn);
    public bool CheckAllReadyCheckedAttendee(Guid attendeeId);
}
