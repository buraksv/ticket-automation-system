using System.Text.Json.Serialization;
using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketPlaces;

public sealed class TicketPlaceCreateRequestDto : IDto
{
    [JsonIgnore]
    public short AdminId { get; set; }
    [JsonIgnore]
    public string IpAddress { get; set; }
    public string PlaceName { get; set; } 
    public bool IsActive { get; set; }

    public TicketPlaceConfigurationsDto TicketPlaceConfigurations { get; set; }
}