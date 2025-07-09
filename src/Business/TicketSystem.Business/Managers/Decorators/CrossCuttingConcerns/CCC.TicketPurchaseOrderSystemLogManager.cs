using Gronio.Database.Abstraction;
using TicketSystem.Business.Managers.Main;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.TicketPurchaseOrderSystemLogs;

namespace TicketSystem.Business.Managers;

internal sealed class CccTicketPurchaseOrderSystemLogManager : TicketPurchaseOrderSystemLogManager
{
    public CccTicketPurchaseOrderSystemLogManager(ITicketPurchaseOrderSystemLogRepository ticketPurchaseOrderSystemLogRepository) 
        : base(ticketPurchaseOrderSystemLogRepository)
    {
    }

    public override ValueTask<TicketPurchaseOrderSystemLogListItemDto> CreateAsync(TicketPurchaseOrderSystemLogCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        return base.CreateAsync(request, cancellationToken);
    }

    public override ValueTask<PagedResult<TicketPurchaseOrderSystemLogListItemDto>> PagedListAsync(TicketPurchaseOrderSystemLogSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        return base.PagedListAsync(request, cancellationToken);
    }
}