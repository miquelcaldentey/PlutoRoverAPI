using Newtonsoft.Json;

namespace PlutoRoverAPI.Models.Enums;

public enum Commands
{
    [JsonProperty("F")]
    Front,
    
    [JsonProperty("B")]
    Back,
    
    [JsonProperty("L")]
    Left,
    
    [JsonProperty("R")]
    Right
}
