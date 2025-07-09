using Gronio.Database.Abstraction;
using Mapster;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseOrderSystemLogs;

namespace TicketSystem.Business.Managers.Main;

internal class TicketPurchaseOrderSystemLogManager : ITicketPurchaseOrderSystemLogManager
{
    protected readonly ITicketPurchaseOrderSystemLogRepository TicketPurchaseOrderSystemLogRepository;

    public TicketPurchaseOrderSystemLogManager(ITicketPurchaseOrderSystemLogRepository ticketPurchaseOrderSystemLogRepository)
    {
        TicketPurchaseOrderSystemLogRepository = ticketPurchaseOrderSystemLogRepository;
    }

    public virtual async ValueTask<TicketPurchaseOrderSystemLogListItemDto> CreateAsync(TicketPurchaseOrderSystemLogCreateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketPurchaseOrderSystemLog>();

        var result = await TicketPurchaseOrderSystemLogRepository.CreateAsync(entity, cancellationToken);

        return entity.Adapt<TicketPurchaseOrderSystemLogListItemDto>();
    }

    public virtual ValueTask<PagedResult<TicketPurchaseOrderSystemLogListItemDto>> PagedListAsync(TicketPurchaseOrderSystemLogSearchRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return TicketPurchaseOrderSystemLogRepository.PagedListAsync(request, cancellationToken);
    }
}