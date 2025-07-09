using Gronio.Database.Abstraction;
using Gronio.Utility.Extensions;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseOrderSystemLogs;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Repository;

internal sealed class TicketPurchaseOrderSystemLogRepository : RepositoryFactory<TicketPurchaseOrderSystemLog, long>, ITicketPurchaseOrderSystemLogRepository
{
    public TicketPurchaseOrderSystemLogRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> CreateAsync(TicketPurchaseOrderSystemLog entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public ValueTask<PagedResult<TicketPurchaseOrderSystemLogListItemDto>> PagedListAsync(TicketPurchaseOrderSystemLogSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        var filter = PredicateBuilder.True<TicketPurchaseOrderSystemLog>();
        if (request.SearchTerm.IsNotNullOrEmptyAndWhiteSpace())
        {
            filter = filter.And(x => x.LogMessage.ToLower().Contains(request.SearchTerm.ToLower()));
        }

        if (request.LogType != null && request.LogType != SystemLogTypeEnum.None)
        {
            filter = filter.And(x => x.LogType == request.LogType);
        }

        Func<IQueryable<TicketPurchaseOrderSystemLog>, IOrderedQueryable<TicketPurchaseOrderSystemLog>> orderBy = request.Order switch
        {
            TicketPurchaseOrderSystemLogOrderEnum.CreatedTimeAscending => x => x.OrderBy(y => y.CreatedTime),
            TicketPurchaseOrderSystemLogOrderEnum.CreatedTimeDescending => x => x.OrderByDescending(y => y.CreatedTime),
            _ => null,
        };

        return PaginationRepository.GetPagedListAsync<TicketPurchaseOrderSystemLogListItemDto>(request.Page, request.PageSize, filter, orderBy, cancellationToken);
    }
}