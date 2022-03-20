using Microsoft.AspNetCore.Mvc;
using PlutoRoverAPI.Infrastructure.Base;
using PlutoRoverAPI.Services.Positions.Interfaces;

namespace PlutoRoverAPI.Controllers.Position;

[ApiController]
[Route("api")]
public class PositionController : BaseController
{
    private readonly IPositionService _positionService;

    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }

    [HttpGet("position")]
    public IActionResult Move()
    {
        return Execute(() => _positionService.GetCurrentPosition());
    }
}
