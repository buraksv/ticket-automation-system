using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.Teams;

public sealed class TeamSearchRequestDto : PagingSearchBaseDtoBase
{
    public TeamPagedListOrderEnum? Order { get; set; } = TeamPagedListOrderEnum.CreatedTimeDescending;
    public TicketSystemTypeEnum TicketSystem { get; set; } = TicketSystemTypeEnum.None;
}