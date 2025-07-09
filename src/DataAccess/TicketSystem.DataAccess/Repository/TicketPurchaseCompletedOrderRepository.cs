using Gronio.Database.Abstraction;
using Gronio.Utility.Extensions;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseCompletedOrders;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Repository;

internal sealed class TicketPurchaseCompletedOrderRepository : RepositoryFactory<TicketPurchaseCompletedOrder, int>, ITicketPurchaseCompletedOrderRepository
{
    public TicketPurchaseCompletedOrderRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> CreateAsync(TicketPurchaseCompletedOrder entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<bool> UpdateAsync(TicketPurchaseCompletedOrder entity, CancellationToken cancellationToken = new())
    {
        UpdateRepository.Update(entity);
        var result = await UpdateRepository.SaveAsync(cancellationToken);

        return result > 0;
    }

    public async ValueTask<TicketPurchaseCompletedOrderDetailDto> GetByIdAsync(TicketPurchaseCompletedOrderGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await QueryRepository.GetByIdFirstOrDefaultAsync<TicketPurchaseCompletedOrderDetailDto>(request.Id, cancellationToken: cancellationToken);
    }

    public ValueTask<PagedResult<TicketPurchaseCompletedOrderListItemDto>> PagedListAsync(TicketPurchaseCompletedOrderSearchRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var filter = PredicateBuilder.True<TicketPurchaseCompletedOrder>();
        if (request.SearchTerm.IsNotNullOrEmptyAndWhiteSpace())
        {
            filter = filter.And(x => x.TicketPurchaseOrder.Name.ToLower().Contains(request.SearchTerm.ToLower()));
            filter = filter.Or(x => x.TicketPurchaseOrder.Id.ToString() == request.SearchTerm);
        }

        Func<IQueryable<TicketPurchaseCompletedOrder>, IOrderedQueryable<TicketPurchaseCompletedOrder>> orderBy = request.Order switch
        {
            TicketPurchaseOrderSystemLogOrderEnum.CreatedTimeAscending => x => x.OrderBy(y => y.CreatedTime),
            TicketPurchaseOrderSystemLogOrderEnum.CreatedTimeDescending => x => x.OrderByDescending(y => y.CreatedTime),
            _ => null,
        };

        return PaginationRepository.GetPagedListAsync<TicketPurchaseCompletedOrderListItemDto>(request.Page, request.PageSize, filter, orderBy, cancellationToken);
    }
}