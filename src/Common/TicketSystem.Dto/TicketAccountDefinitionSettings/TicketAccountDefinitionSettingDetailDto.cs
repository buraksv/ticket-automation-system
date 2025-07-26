using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketAccountDefinitionSettings;

public sealed class TicketAccountDefinitionSettingDetailDto : IDto
{
    public int Id { get; set; }
    public int TicketAccountDefinitionId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
