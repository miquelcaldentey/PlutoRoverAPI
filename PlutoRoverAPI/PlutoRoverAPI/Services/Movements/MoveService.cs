using PlutoRoverAPI.Helpers;
using PlutoRoverAPI.Infrastructure.Exceptions;
using PlutoRoverAPI.Models.Common;
using PlutoRoverAPI.Models.Enums;
using PlutoRoverAPI.Services.Movements.Interfaces;
using PlutoRoverAPI.Services.Positions.Interfaces;

namespace PlutoRoverAPI.Services.Movements;

public class MoveService : IMoveService
{
    private object _lock = new object();
    private IPositionService _positionService;

    public MoveService(IPositionService positionService)
    {
        _positionService = positionService;
    }

    public Position Move(string movements)
    {
        if (!ValidationHelper.AreMovementsOk(movements))
            throw new BadRequestException();

        var commands = GetCommands(movements);

        lock(_lock)
        {
            var position = ExecuteCommands(commands);

            _positionService.UpdatePosition(position);

            return position;
        }
    }

    private IEnumerable<Commands> GetCommands(string movements)
    {
        return movements.Select(
            m => (Commands)Enum.Parse(typeof(Commands), m.ToString())
            );
    }

    private Position ExecuteCommands(IEnumerable<Commands> commands)
    {
        var position = _positionService.GetCurrentPosition();

        foreach (var command in commands)
        {
            switch (command)
            {
                case Commands.F:
                    ExcuteMoveCommand(position, Commands.F);
                    break;

                case Commands.B:
                    ExcuteMoveCommand(position, Commands.B);
                    break;

                case Commands.L:
                    position.FacingPosition = position.FacingPosition.Previous();
                    break;

                case Commands.R:
                    position.FacingPosition = position.FacingPosition.Next();
                    break;

                default:
                    break;
            }
        }

        return position;
    }

    private void ExcuteMoveCommand(Position position, Commands command)
    {
        var movement =
            command == Commands.F
            ? 1
            : -1;

        switch (position.FacingPosition)
        {
            case FacingPosition.N:
                position.Y += movement;
                break;

            case FacingPosition.E:
                position.X += movement;
                break;

            case FacingPosition.S:
                position.Y -= movement;
                break;

            case FacingPosition.W:
                position.X -= movement;
                break;
        }
    }    
}
