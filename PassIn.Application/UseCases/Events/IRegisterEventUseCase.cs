using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Events;
public interface IRegisterEventUseCase
{
    public ResponseRegisteredJson Execute(RequestEventJson request);
    public void Validate(RequestEventJson request);
}
