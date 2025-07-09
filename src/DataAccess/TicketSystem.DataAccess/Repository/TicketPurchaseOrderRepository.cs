using Gronio.Database.Abstraction;
using Gronio.Utility.Extensions;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseOrders;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Repository;

internal sealed class TicketPurchaseOrderRepository : RepositoryFactory<TicketPurchaseOrder, int>, ITicketPurchaseOrderRepository
{
    public TicketPurchaseOrderRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> CreateAsync(TicketPurchaseOrder entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<bool> UpdateAsync(TicketPurchaseOrder entity, CancellationToken cancellationToken = new())
    {
        UpdateRepository.Update(entity);
        var result = await UpdateRepository.SaveAsync(cancellationToken);

        return result > 0;
    }

    public async ValueTask<TicketPurchaseOrderDetailDto> GetByIdAsync(TicketPurchaseOrderGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await QueryRepository.GetByIdFirstOrDefaultAsync<TicketPurchaseOrderDetailDto>(request.Id, cancellationToken: cancellationToken);
    }

    public ValueTask<PagedResult<TicketPurchaseOrderListItemDto>> PagedListAsync(TicketPurchaseOrderSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        var filter = PredicateBuilder.True<TicketPurchaseOrder>();
        if (request.SearchTerm.IsNotNullOrEmptyAndWhiteSpace())
        {
            filter = filter.And(x => x.Name.ToLower().Contains(request.SearchTerm.ToLower()));
            filter = filter.Or(x => x.Id.ToString() == request.SearchTerm);
        }

        if (request.TicketSystem != null && request.TicketSystem != TicketSystemTypeEnum.None)
        {
            filter = filter.And(x => x.TicketSystem == request.TicketSystem);
        }

        if (request.TeamId.HasValue && request.TeamId.Value > 0)
        {
            filter = filter.And(x => x.TeamId == request.TeamId.Value);
        }

        Func<IQueryable<TicketPurchaseOrder>, IOrderedQueryable<TicketPurchaseOrder>> orderBy = request.Order switch
        {
            TicketPurchaseOrderOrderEnum.NameAscending => x => x.OrderBy(y => y.Name),
            TicketPurchaseOrderOrderEnum.NameDescending => x => x.OrderByDescending(y => y.Name),
            TicketPurchaseOrderOrderEnum.CreatedTimeAscending => x => x.OrderBy(y => y.CreatedTime),
            TicketPurchaseOrderOrderEnum.CreatedTimeDescending => x => x.OrderByDescending(y => y.CreatedTime),
            _ => null,
        };

        return PaginationRepository.GetPagedListAsync<TicketPurchaseOrderListItemDto>(request.Page, request.PageSize, filter, orderBy, cancellationToken);
    }
}