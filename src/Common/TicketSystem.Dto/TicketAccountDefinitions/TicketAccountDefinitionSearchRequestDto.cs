using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketAccountDefinitions;

public sealed class TicketAccountDefinitionSearchRequestDto : PagingSearchBaseDtoBase
{
    public TicketAccountDefinitionPagedListOrderEnum? Order { get; set; } =
        TicketAccountDefinitionPagedListOrderEnum.CreatedTimeDescending;
    public TicketAccountTypeEnum AccountType { get; set; }
    public TicketSystemTypeEnum TicketSystem { get; set; }
}