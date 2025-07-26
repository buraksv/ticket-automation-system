using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketAccountDefinitionSettings;

public sealed class TicketAccountDefinitionSettingCreateRequestDto : IDto
{
    public int TicketAccountDefinitionId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
