using FluentAssertions;
using PlutoRoverAPI.Helpers;
using PlutoRoverAPI.Models.Common;
using PlutoRoverAPI.Models.Enums;
using Xunit;

namespace PlutoRoverTest;

public class EnumHelperShould
{
    [Fact]
    public void EnumHelperShouldGiveNextEnum()
    {
        var expectedResult = FacingPosition.N;

        var actualResult = FacingPosition.W.Next();

        actualResult.Should().Be(expectedResult);
    }

    [Fact]
    public void EnumHelperShouldGivePreviousEnum()
    {
        var expectedResult = FacingPosition.N;

        var actualResult = FacingPosition.E.Previous();

        actualResult.Should().Be(expectedResult);
    }
}
