using PassIn.Domain.Entities.Checkin;

namespace PassIn.Infrastructure.CheckinService;
public class CheckinService : ICheckinService
{
    private readonly PassInDbContext _dbContext;

    public CheckinService()
    {
        _dbContext = new PassInDbContext();
    }

    public bool CheckAllReadyCheckedAttendee (Guid attendeeId)
    {
        return _dbContext.CheckIns.Any(ch => ch.Attendee_Id == attendeeId);
    }

    public void DoAttendeeCheckin(CheckIn checkIn)
    {
        _dbContext.CheckIns.Add(checkIn);
        _dbContext.SaveChanges();
    }
}
