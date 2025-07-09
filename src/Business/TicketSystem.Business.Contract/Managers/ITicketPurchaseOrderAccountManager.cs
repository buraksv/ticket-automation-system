using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.TicketPurchaseOrderAccounts;

namespace TicketSystem.Business.Contract.Managers;

public interface ITicketPurchaseOrderAccountManager : IBusinessEngine
{
    ValueTask<TicketPurchaseOrderAccountDetailDto> CreateAsync(TicketPurchaseOrderAccountCreateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketPurchaseOrderAccountDetailDto> UpdateAsync(TicketPurchaseOrderAccountUpdateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<List<TicketPurchaseOrderAccountListItemDto>> GetAccountsByOrderIdAsync(TicketPurchaseOrderAccountGetByOrderIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<bool> DeleteAsync(TicketPurchaseOrderAccountGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new());
}