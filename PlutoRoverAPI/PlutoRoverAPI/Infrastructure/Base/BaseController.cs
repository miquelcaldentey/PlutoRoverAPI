using Microsoft.AspNetCore.Mvc;
using PlutoRoverAPI.Infrastructure.Exceptions;

namespace PlutoRoverAPI.Infrastructure.Base;

public class BaseController : ControllerBase
{
    public IActionResult Execute<T>(Func<T> action)
    {
        try
        {
            return Ok(action());
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
