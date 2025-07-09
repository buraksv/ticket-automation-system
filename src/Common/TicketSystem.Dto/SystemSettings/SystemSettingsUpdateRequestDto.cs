using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.SystemSettings;

public sealed class SystemSettingsUpdateRequestDto : IDto
{
    public short AdminId { get; set; }
    public string IpAddress { get; set; }
    public string SystemName { get; set; }
}