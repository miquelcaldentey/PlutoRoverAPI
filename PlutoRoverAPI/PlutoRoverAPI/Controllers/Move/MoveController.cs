using Microsoft.AspNetCore.Mvc;

namespace PlutoRoverAPI.Controllers.Move;

[ApiController]
[Route("api")]
public class MoveController : ControllerBase
{

    [HttpPost("move")]
    public IActionResult Move(string movements)
    {
        return Ok();
    }
}
