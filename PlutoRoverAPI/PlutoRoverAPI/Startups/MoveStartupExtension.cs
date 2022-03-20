using PlutoRoverAPI.Infrastructure.Decorators;
using PlutoRoverAPI.Services.Movements;
using PlutoRoverAPI.Services.Movements.Interfaces;
using PlutoRoverAPI.Services.Positions.Interfaces;

namespace PlutoRoverAPI.Startups;

public static class MoveStartupExtension
{
    public static void AddMove(this IServiceCollection services)
    {
        services.AddSingleton<IMoveService>(r =>
            new MoveServiceLoggerDecorator(
                new MoveService(r.GetRequiredService<IPositionService>())
                ));
    }
}
