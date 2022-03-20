using Newtonsoft.Json;
using PlutoRoverAPI.Models.Common;
using PlutoRoverAPI.Services.Movements.Interfaces;

namespace PlutoRoverAPI.Infrastructure.Decorators;

public class MoveServiceLoggerDecorator : IMoveService
{
    private readonly IMoveService _inner;
    private readonly ILogger<MoveServiceLoggerDecorator> _logger;

    public MoveServiceLoggerDecorator(IMoveService inner, ILogger<MoveServiceLoggerDecorator> logger)
    {
        this._inner = inner;
        this._logger = logger;
    }

    public Position Move(string movements)
    {
        try
        {
            _logger.LogInformation("Requested movements {Movements}", movements);
            
            var result = _inner.Move(movements);

            var positionSerialized = Serialize(result);
            _logger.LogInformation("Movements done, new position {Position}", positionSerialized);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error for Requested movements {Movements}, {Error}", movements, ex.Message);
            throw;
        }

        
    }

    private static string Serialize(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}
