using PlutoRoverAPI.Infrastructure.Decorators;
using PlutoRoverAPI.Services.Move;
using PlutoRoverAPI.Services.Move.Interfaces;

namespace PlutoRoverAPI.Startups
{
    public static class MoveStartupExtension
    {
        public static void AddMove(this IServiceCollection services)
        {
            services.AddScoped<IMoveService>(r =>
                new MoveServiceLoggerDecorator(
                    new MoveService()
                    ));
        }
    }
}
