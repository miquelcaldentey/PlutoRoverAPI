using PlutoRoverAPI.Models.Common;
using PlutoRoverAPI.Services.Move.Interfaces;

namespace PlutoRoverAPI.Infrastructure.Decorators
{
    public class MoveServiceLoggerDecorator : IMoveService
    {
        private readonly IMoveService _inner;
        
        public MoveServiceLoggerDecorator(IMoveService inner)
        {
            this._inner = inner;
        }

        public Position Move(string movements)
        {
            return _inner.Move(movements);
        }
    }
}
