using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.Admin;

public sealed class AdminSearchRequestDto : PagingSearchBaseDtoBase
{
    public AdminPagedListOrderEnum? Order { get; set; } = AdminPagedListOrderEnum.CreatedTimeDescending;
}