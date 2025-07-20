using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketProviderSetting;

public sealed class TicketProviderSettingGetByKeyRequestDto : IDto
{
    public TicketSystemTypeEnum Provider { get; set; }
    public string Key { get; set; }
}
