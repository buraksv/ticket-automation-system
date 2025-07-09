using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseOrderAccounts;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface ITicketPurchaseOrderAccountRepository : IRepository
{
    ValueTask<bool> CreateAsync(TicketPurchaseOrderAccount entity, CancellationToken cancellationToken = new());
    ValueTask<bool> UpdateAsync(TicketPurchaseOrderAccount entity, CancellationToken cancellationToken = new());
    ValueTask<List<TicketPurchaseOrderAccountListItemDto>> GetAccountsByOrderIdAsync(TicketPurchaseOrderAccountGetByOrderIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<bool> SoftDeleteAsync(TicketPurchaseOrderAccountGetByIdRequestDto request, CancellationToken cancellationToken = new());
}