using FluentAssertions;
using PlutoRoverAPI.Models.Common;
using PlutoRoverAPI.Models.Enums;
using PlutoRoverAPI.Services.Positions;
using Xunit;

namespace PlutoRoverTest;

public class PositionServiceShould
{
    [Fact]
    public void PositionShouldCreateAPosition()
    {
        PositionService service = new();

        var actualResult = service.GetCurrentPosition();

        actualResult.Should().NotBeNull();
    }

    [Fact]
    public void PositionShouldUpdatePosition()
    {
        PositionService service = new();

        var expectedResult = CreatePosition(1, 1, FacingPosition.E);
        
        service.UpdatePosition(expectedResult);

        var actualResult = service.GetCurrentPosition();

        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    private static Position CreatePosition(int x, int y, FacingPosition facingPosition)
    {
        return new Position
        {
            X = x,
            Y = y,
            FacingPosition = facingPosition,
        };
    }
}
