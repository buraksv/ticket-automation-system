using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketProviderSetting;

public sealed class TicketProviderSettingDetailDto : IDto
{
    public int Id { get; set; }
    public TicketSystemTypeEnum Provider { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
