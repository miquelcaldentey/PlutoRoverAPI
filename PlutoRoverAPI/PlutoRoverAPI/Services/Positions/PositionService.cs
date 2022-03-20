using PlutoRoverAPI.Models.Common;
using PlutoRoverAPI.Models.Enums;
using PlutoRoverAPI.Services.Positions.Interfaces;

namespace PlutoRoverAPI.Services.Positions;

public class PositionService : IPositionService
{
    private static readonly Random _random = new();
    private Position Position = CreatePosition();

    public Position GetCurrentPosition()
        => Position;

    private static Position CreatePosition()
    {
        return new Position
        {
            X = _random.Next(-20, 20),
            Y = _random.Next(-20, 20),
            FacingPosition = (FacingPosition)_random.Next(0, 3)
        };        
    }

    public void UpdatePosition(Position position)
    {
        this.Position = position;        
    }
}
