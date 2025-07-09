using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseOrderAccounts;

namespace TicketSystem.DataAccess.Repository;

internal sealed class TicketPurchaseOrderAccountRepository : RepositoryFactory<TicketPurchaseOrderAccount, int>, ITicketPurchaseOrderAccountRepository
{
    public TicketPurchaseOrderAccountRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> CreateAsync(TicketPurchaseOrderAccount entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<bool> UpdateAsync(TicketPurchaseOrderAccount entity, CancellationToken cancellationToken = new())
    {
        UpdateRepository.Update(entity);
        var result = await UpdateRepository.SaveAsync(cancellationToken);

        return result > 0;
    }

    public async ValueTask<List<TicketPurchaseOrderAccountListItemDto>> GetAccountsByOrderIdAsync(TicketPurchaseOrderAccountGetByOrderIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await QueryRepository.GetListAsync<TicketPurchaseOrderAccountListItemDto>(x => x.TicketPurchaseOrderId == request.OrderId, o => o.OrderByDescending(y => y.UpdatedTime), cancellationToken: cancellationToken);
    }

    public async ValueTask<bool> SoftDeleteAsync(TicketPurchaseOrderAccountGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        var result = await SoftDeleteRepository.SoftDeleteAsync(request.Id, cancellationToken);

        return result > 0;
    }
}