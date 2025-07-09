using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.Teams;

public sealed class TeamListItemDto : IDto
{
    public short Id { get; set; }
    public string TeamName { get; set; }
    public TicketSystemTypeEnum TicketSystem { get; set; }
    public string TicketSystemId { get; set; }
    public DateTime CreatedTime { get; set; }
    public bool IsActive { get; set; }
}