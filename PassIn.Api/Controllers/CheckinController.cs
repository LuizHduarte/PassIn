using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Checkin;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CheckinController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    [Route("{attendeeId}")]
    public IActionResult Checkin([FromServices] IAttendeeCheckinUseCase useCase, [FromRoute] Guid attendeeId)
    {
        var response = useCase.Execute(attendeeId);
        return Created(string.Empty, response);
    }
}
