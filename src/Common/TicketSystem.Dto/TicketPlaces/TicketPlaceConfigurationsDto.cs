using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketPlaces;

public sealed class TicketPlaceConfigurationsDto : IDto
{
    public TicketSystemTypeEnum TicketSystem { get; set; }
    public string TicketSystemId { get; set; }
    public Dictionary<string, string> Definitions { get; set; }
}