namespace PlutoRoverAPI.Services.Positions.Interfaces;

public interface IPositionService
{
    Models.Common.Position GetCurrentPosition();
    void UpdatePosition(Models.Common.Position position);
}
