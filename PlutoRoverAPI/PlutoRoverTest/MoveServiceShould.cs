using FluentAssertions;
using PlutoRoverAPI.Helpers;
using PlutoRoverAPI.Models.Common;
using PlutoRoverAPI.Models.Enums;
using PlutoRoverAPI.Services.Movements;
using PlutoRoverAPI.Services.Positions;
using Xunit;

namespace PlutoRoverTest;

public class MoveServiceShould
{
    [Fact]
    public void RoverShouldMoveOneInYAxis()
    {
        PositionService positionService = new();
        MoveService service = new(positionService);

        positionService.UpdatePosition(CreateDefaultPosition());

        var expectedResult = CreatePosition(0, 1, FacingPosition.N);
        
        var actualResult = service.Move("F");

        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void RoverShouldMoveOneInXAxis()
    {
        PositionService positionService = new();
        MoveService service = new(positionService);

        positionService.UpdatePosition(CreatePosition(0, 0, FacingPosition.E));

        var expectedResult = CreatePosition(1, 0, FacingPosition.E);

        var actualResult = service.Move("F");

        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void RoverShouldRotateLeft()
    {
        PositionService positionService = new();
        MoveService service = new(positionService);

        positionService.UpdatePosition(CreateDefaultPosition());

        var expectedResult = CreatePosition(0, 0, FacingPosition.W);

        var actualResult = service.Move("L");

        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void RoverShouldRotateRight()
    {
        PositionService positionService = new();
        MoveService service = new(positionService);

        positionService.UpdatePosition(CreateDefaultPosition());

        var expectedResult = CreatePosition(0, 0, FacingPosition.E);

        var actualResult = service.Move("R");

        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void RoverShouldRotateAndMove()
    {
        PositionService positionService = new();
        MoveService service = new(positionService);

        positionService.UpdatePosition(CreateDefaultPosition());

        var expectedResult = CreatePosition(2, 2, FacingPosition.E);

        var actualResult = service.Move("FFRFF");

        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void CommandValidationShouldWork()
    {
        var movements = "FFRF";
        
        var actualResult = ValidationHelper.AreMovementsOk(movements);

        actualResult.Should().BeTrue();
    }

    [Fact]
    public void CommandValidationShouldNotWork()
    {
        var movements = "AXRF";

        var actualResult = ValidationHelper.AreMovementsOk(movements);

        actualResult.Should().BeFalse();
    }

    private static Position CreateDefaultPosition()
    {
        return new Position
        {
            X = 0,
            Y = 0,
            FacingPosition = FacingPosition.N,
        };
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
