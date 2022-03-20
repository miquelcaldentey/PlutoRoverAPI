using PlutoRoverAPI.Models.Common;

namespace PlutoRoverAPI.Services.Movements.Interfaces;

public interface IMoveService
{
    Position Move(string movements);
}
