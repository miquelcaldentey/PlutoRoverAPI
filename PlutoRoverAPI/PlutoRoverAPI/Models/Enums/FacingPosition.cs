using Newtonsoft.Json;

namespace PlutoRoverAPI.Models.Enums;

public enum FacingPosition
{
    [JsonProperty("N")]
    North,

    [JsonProperty("S")]
    South,

    [JsonProperty("E")]
    East,

    [JsonProperty("W")]
    West
}
