using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketPurchaseOrderSystemLogs;

public sealed class TicketPurchaseOrderSystemLogSearchRequestDto : PagingSearchBaseDtoBase
{
    public TicketPurchaseOrderSystemLogOrderEnum? Order { get; set; } =
        TicketPurchaseOrderSystemLogOrderEnum.CreatedTimeDescending;

    public SystemLogTypeEnum LogType { get; set; }
}