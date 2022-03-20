using PlutoRoverAPI.Models.Enums;

namespace PlutoRoverAPI.Models.Common
{
    public class Position : Coordinates
    {
        public FacingPosition FacingPosition { get; set; }
    }
}
