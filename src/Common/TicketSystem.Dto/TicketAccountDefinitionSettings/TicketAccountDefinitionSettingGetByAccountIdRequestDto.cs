using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketAccountDefinitionSettings;

public sealed class TicketAccountDefinitionSettingGetByAccountIdRequestDto : IDto
{
    public int AccountId { get; set; }
}
