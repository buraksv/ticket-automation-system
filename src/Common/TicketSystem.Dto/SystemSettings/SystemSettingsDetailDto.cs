using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.SystemSettings;

public sealed class SystemSettingsDetailDto : IDto
{
    public byte Id { get; set; }
    public string SystemName { get; set; } 
}
