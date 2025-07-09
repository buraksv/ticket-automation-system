using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketPlaces;

public sealed class TicketPlaceDetailDto : IDto
{
    public short Id { get; set; }
    public string PlaceName { get; set; }
    public DateTime CreatedTime { get; set; }
    public bool IsActive { get; set; }

    public TicketPlaceConfigurationsDto TicketPlaceConfigurations { get; set; }
}