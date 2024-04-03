using PassIn.Communication.Responses;
using PassIn.Domain.Entities.Events;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events;
public class GetEventByIdUseCase : IGetEventByIdUseCase
{
    private readonly IEventService _eventService;

    public GetEventByIdUseCase(IEventService eventService)
    {
        _eventService = eventService;
    }

    public ResponseEventJson Execute(Guid id)
    {

        var entity = _eventService.FindEventById(id);

        if (entity is null)
        {
            throw new NotFoundException("An event with this id does not exist.");
        }

        return new ResponseEventJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Details = entity.Details,
            Maximum_Attendees = entity.Maximum_Attendees,
            AttendeesAmount = entity.Attendees.Count()
        };
    }
}
