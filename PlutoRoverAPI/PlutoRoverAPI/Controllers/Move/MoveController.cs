using Microsoft.AspNetCore.Mvc;
using PlutoRoverAPI.Services.Move.Interfaces;

namespace PlutoRoverAPI.Controllers.Move;

[ApiController]
[Route("api")]
public class MoveController : ControllerBase
{
    private readonly IMoveService _moveService;

    public MoveController(IMoveService moveService)
    {
        _moveService = moveService;
    }

    [HttpPost("move")]
    public IActionResult Move(string movements)
    {
        return Ok(_moveService.Move(movements));
    }
}
