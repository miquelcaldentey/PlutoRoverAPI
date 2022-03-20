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
            LogInformation(movements, "Requested movements {Movements}");
            
            var result = _inner.Move(movements);

            LogInformation(result, "Movements done, new position {Position}");

            return result;
        }
        catch (Exception ex)
        {
            LogError("Error for Requested movements {Movements}, {Error}", movements, ex.Message);
            throw;
        }
    }

    private void LogInformation(object request, string text)
    {
        var rqSerialized = Serialize(request);
        //PubSub Log

        _logger.LogInformation(text, rqSerialized);
    }

    private void LogError(string text, params object?[] args)
    {
        _logger.LogError(text, args);
    }

    private static string Serialize(object obj)
    {
        return 
            obj is string 
            ? (string)obj 
            : JsonConvert.SerializeObject(obj);
    }
}
