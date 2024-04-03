using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Events;
public interface IGetEventByIdUseCase
{
    public ResponseEventJson Execute(Guid id);
}
