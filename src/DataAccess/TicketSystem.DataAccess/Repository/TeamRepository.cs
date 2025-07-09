using Gronio.Database.Abstraction;
using Gronio.Utility.Extensions;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.Teams;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Repository;

internal sealed class TeamRepository : RepositoryFactory<Team, short>, ITeamRepository
{
    public TeamRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> CreateAsync(Team entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<bool> UpdateAsync(Team entity, CancellationToken cancellationToken = new())
    {
        UpdateRepository.Update(entity);
        var result = await UpdateRepository.SaveAsync(cancellationToken);

        return result > 0;
    }

    public async ValueTask<TeamDetailDto> GetByIdAsync(TeamGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await QueryRepository.GetByIdFirstOrDefaultAsync<TeamDetailDto>(request.Id, cancellationToken: cancellationToken);
    }

    public ValueTask<PagedResult<TeamListItemDto>> PagedListAsync(TeamSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        var filter = PredicateBuilder.True<Team>();
        if (request.SearchTerm.IsNotNullOrEmptyAndWhiteSpace())
        {
            filter = filter.And(x => x.TeamName.ToLower().Contains(request.SearchTerm.ToLower()));
            filter = filter.Or(x => x.Id.ToString() == request.SearchTerm);
        }

        if (request.TicketSystem != null && request.TicketSystem != TicketSystemTypeEnum.None)
        {
            filter = filter.And(x => x.TicketSystem == request.TicketSystem);
        }

        Func<IQueryable<Team>, IOrderedQueryable<Team>> orderBy = request.Order switch
        {
            TeamPagedListOrderEnum.TeamNameAscending => x => x.OrderBy(y => y.TeamName),
            TeamPagedListOrderEnum.TeamNameDescending => x => x.OrderByDescending(y => y.TeamName),
            TeamPagedListOrderEnum.CreatedTimeAscending => x => x.OrderBy(y => y.CreatedTime),
            TeamPagedListOrderEnum.CreatedTimeDescending => x => x.OrderByDescending(y => y.CreatedTime),
            _ => null,
        };

        return PaginationRepository.GetPagedListAsync<TeamListItemDto>(request.Page, request.PageSize, filter, orderBy, cancellationToken);
    }

    public async ValueTask<bool> ToggleStatusAsync(TeamGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        var result = await SwitchRepository.ToggleStatusAsync(request.Id, cancellationToken);
        return result > 1;
    }
}