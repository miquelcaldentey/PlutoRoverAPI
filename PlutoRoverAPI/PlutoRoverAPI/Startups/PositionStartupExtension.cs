using PlutoRoverAPI.Services.Positions;
using PlutoRoverAPI.Services.Positions.Interfaces;

namespace PlutoRoverAPI.Startups;

public static class PositionStartupExtension
{
    public static void AddPosition(this IServiceCollection services)
    {
        services.AddSingleton<IPositionService, PositionService>();
    }
}
