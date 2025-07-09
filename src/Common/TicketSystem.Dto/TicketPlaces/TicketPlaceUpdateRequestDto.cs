using System.Text.Json.Serialization;

namespace TicketSystem.Dto.TicketPlaces;

public sealed class TicketPlaceUpdateRequestDto
{
    [JsonIgnore]
    public short AdminId { get; set; }
    [JsonIgnore]
    public string IpAddress { get; set; }
    public short Id { get; set; }
    public string PlaceName { get; set; }
    public bool IsActive { get; set; }

    public TicketPlaceConfigurationsDto TicketPlaceConfigurations { get; set; }
}