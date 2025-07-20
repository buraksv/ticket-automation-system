using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketProviderSetting;

public sealed class TicketProviderSettingGetByProviderRequestDto : IDto
{
    public TicketSystemTypeEnum Provider { get; set; }
}
