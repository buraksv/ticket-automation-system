using Mapster;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseOrderAccounts;

namespace TicketSystem.Business.Managers.Main;

internal class TicketPurchaseOrderAccountManager : ITicketPurchaseOrderAccountManager
{
    protected readonly ITicketPurchaseOrderAccountRepository TicketPurchaseOrderAccountRepository;

    public TicketPurchaseOrderAccountManager(ITicketPurchaseOrderAccountRepository ticketPurchaseOrderAccountRepository)
    {
        TicketPurchaseOrderAccountRepository = ticketPurchaseOrderAccountRepository;
    }

    public virtual async ValueTask<TicketPurchaseOrderAccountDetailDto> CreateAsync(TicketPurchaseOrderAccountCreateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketPurchaseOrderAccount>();

        var result = await TicketPurchaseOrderAccountRepository.CreateAsync(entity, cancellationToken);

        return entity.Adapt<TicketPurchaseOrderAccountDetailDto>();
    }

    public virtual async ValueTask<TicketPurchaseOrderAccountDetailDto> UpdateAsync(TicketPurchaseOrderAccountUpdateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketPurchaseOrderAccount>();

        var result = await TicketPurchaseOrderAccountRepository.UpdateAsync(entity, cancellationToken);

        return entity.Adapt<TicketPurchaseOrderAccountDetailDto>();
    }

    public virtual ValueTask<List<TicketPurchaseOrderAccountListItemDto>> GetAccountsByOrderIdAsync(TicketPurchaseOrderAccountGetByOrderIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return TicketPurchaseOrderAccountRepository.GetAccountsByOrderIdAsync(request, cancellationToken);
    }

    public virtual async ValueTask<bool> DeleteAsync(TicketPurchaseOrderAccountGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new())
    {
        return await TicketPurchaseOrderAccountRepository.SoftDeleteAsync(request, cancellationToken);
    }
}