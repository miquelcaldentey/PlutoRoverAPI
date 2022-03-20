using PlutoRoverAPI.Models.Common;

namespace PlutoRoverAPI.Services.Move.Interfaces;

public interface IMoveService
{
    Position Move(string movements);
}
