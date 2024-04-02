using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.GetById;
public class GetEventByIdUseCase
{
    public ResponseEventJson Execute(Guid id)
    {
        var dbContext = new PassInDbContext();

        //dbContext.Events.Find(id);
        var entity = dbContext.Events.FirstOrDefault(ev => ev.Id == id);
        if (entity is null)
        {
            throw new PassInException("An event with this id does not exist.");
        }

        return new ResponseEventJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Details = entity.Details,
            Maximum_Attendees = entity.Maximum_Attendees,
            AttendeesAmount = -1
        };
    }
}
