using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.RegisterAttendee;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AttendeesController : ControllerBase
{
    [HttpPost]
    [Route("{eventId}/register")]
    [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public IActionResult Register([FromBody] RequestRegisterEventJson request, [FromRoute] Guid eventId)
    {
        var useCase = new RegisterAttendeeOnEventUseCase();
        var response = useCase.Execute(eventId, request);
        return Created(string.Empty, response);

    }
}
