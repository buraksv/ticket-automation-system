using Gronio.Database.Abstraction;
using Gronio.Utility.Extensions;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPlaces;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Repository;

internal sealed class TicketPlaceRepository : RepositoryFactory<TicketPlace, short>, ITicketPlaceRepository
{
    public TicketPlaceRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider) 
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> CreateAsync(TicketPlace entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<bool> UpdateAsync(TicketPlace entity, CancellationToken cancellationToken = new())
    {
        UpdateRepository.Update(entity);
        var result = await UpdateRepository.SaveAsync(cancellationToken);

        return result > 0;
    }

    public async ValueTask<TicketPlaceDetailDto> GetByIdAsync(TicketPlaceGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await QueryRepository.GetByIdFirstOrDefaultAsync<TicketPlaceDetailDto>(request.Id, cancellationToken: cancellationToken);
    }

    public ValueTask<PagedResult<TicketPlaceListItemDto>> PagedListAsync(TicketPlaceSearchRequestDto request, CancellationToken token = new())
    {
        var filter = PredicateBuilder.True<TicketPlace>();
        if (request.SearchTerm.IsNotNullOrEmptyAndWhiteSpace())
        {
            filter = filter.And(x => x.PlaceName.ToLower().Contains(request.SearchTerm.ToLower()));
            filter = filter.Or(x => x.Id.ToString() == request.SearchTerm);
        } 

        Func<IQueryable<TicketPlace>, IOrderedQueryable<TicketPlace>> orderBy = request.Order switch
        {
            TicketPlacePagedListOrderEnum.PlaceNameAscending => x => x.OrderBy(y => y.PlaceName),
            TicketPlacePagedListOrderEnum.PlaceNameDescending => x => x.OrderByDescending(y => y.PlaceName),
            TicketPlacePagedListOrderEnum.CreatedTimeAscending => x => x.OrderBy(y => y.CreatedTime),
            TicketPlacePagedListOrderEnum.CreatedTimeDescending => x => x.OrderByDescending(y => y.CreatedTime),
            _ => null,
        };

        return PaginationRepository.GetPagedListAsync<TicketPlaceListItemDto>(request.Page, request.PageSize, filter, orderBy, token);
    }

    public async ValueTask<bool> ToggleStatusAsync(TicketPlaceGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        var result = await SwitchRepository.ToggleStatusAsync(request.Id, cancellationToken);
        return result > 1;
    }
}