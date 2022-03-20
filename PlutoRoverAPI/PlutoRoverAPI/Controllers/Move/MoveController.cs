using Microsoft.AspNetCore.Mvc;
using PlutoRoverAPI.Infrastructure.Base;
using PlutoRoverAPI.Services.Movements.Interfaces;

namespace PlutoRoverAPI.Controllers.Move;

[ApiController]
[Route("api")]
public class MoveController : BaseController
{
    private readonly IMoveService _moveService;

    public MoveController(IMoveService moveService)
    {
        _moveService = moveService;
    }

    [HttpPost("move")]
    public IActionResult Move(string movements)
    {
        return Execute(() => _moveService.Move(movements));
    }
}
