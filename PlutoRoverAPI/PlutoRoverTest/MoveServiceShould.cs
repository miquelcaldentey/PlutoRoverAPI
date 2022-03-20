using FluentAssertions;
using PlutoRoverAPI.Models.Common;
using PlutoRoverAPI.Models.Enums;
using PlutoRoverAPI.Services.Move;
using Xunit;

namespace PlutoRoverTest
{
    public class MoveServiceShould
    {
        [Fact]
        public void RoverShouldMoveOneInYAxis()
        {
            MoveService service = new();
            var actualResult = service.Move("F");

            var expectedResult = CreatePosition(0, 1, FacingPosition.North);

            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void RoverShouldMoveOneInXAxis()
        {
            MoveService service = new();
            var actualResult = service.Move("RF");

            var expectedResult = CreatePosition(1, 0, FacingPosition.East);

            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void RoverShouldRotateLeft()
        {
            MoveService service = new();
            var actualResult = service.Move("L");

            var expectedResult = CreatePosition(0, 0, FacingPosition.West);

            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void RoverShouldRotateRight()
        {
            MoveService service = new();
            var actualResult = service.Move("R");

            var expectedResult = CreatePosition(0, 0, FacingPosition.East);

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
}