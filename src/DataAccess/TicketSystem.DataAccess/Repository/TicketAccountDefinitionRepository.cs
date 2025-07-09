using Gronio.Database.Abstraction;
using Gronio.Utility.Extensions;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketAccountDefinitions;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Repository;

internal sealed class TicketAccountDefinitionRepository : RepositoryFactory<TicketAccountDefinition, int>, ITicketAccountDefinitionRepository
{
    public TicketAccountDefinitionRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> CreateAsync(TicketAccountDefinition entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<bool> UpdateAsync(TicketAccountDefinition entity, CancellationToken cancellationToken = new())
    {
        UpdateRepository.Update(entity);
        var result = await UpdateRepository.SaveAsync(cancellationToken);

        return result > 0;
    }

    public async ValueTask<TicketAccountDefinitionDetailDto> GetByIdAsync(TicketAccountDefinitionGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await QueryRepository.GetByIdFirstOrDefaultAsync<TicketAccountDefinitionDetailDto>(request.Id, cancellationToken: cancellationToken);
    }

    public ValueTask<PagedResult<TicketAccountDefinitionListItemDto>> PagedListAsync(TicketAccountDefinitionSearchRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var filter = PredicateBuilder.True<TicketAccountDefinition>();
        if (request.SearchTerm.IsNotNullOrEmptyAndWhiteSpace())
        {
            filter = filter.And(x => $"{x.Name.ToLower()} {x.Surname.ToLower()}".ToLower().Contains(request.SearchTerm.ToLower()));
            filter = filter.Or(x => x.Id.ToString() == request.SearchTerm);
        }

        if (request.TicketSystem != null && request.TicketSystem != TicketSystemTypeEnum.None)
        {
            filter = filter.And(x => x.TicketSystem == request.TicketSystem);
        }

        if (request.AccountType != null && request.AccountType != TicketAccountTypeEnum.None)
        {
            filter = filter.And(x => x.AccountType == request.AccountType);
        }

        Func<IQueryable<TicketAccountDefinition>, IOrderedQueryable<TicketAccountDefinition>> orderBy = request.Order switch
        {
            TicketAccountDefinitionPagedListOrderEnum.NameAndSurnameAscending => x => x.OrderBy(y => $"{y.Name} {y.Surname}"),
            TicketAccountDefinitionPagedListOrderEnum.NameAndSurnameDescending => x => x.OrderByDescending(y => $"{y.Name} {y.Surname}"),
            TicketAccountDefinitionPagedListOrderEnum.CreatedTimeAscending => x => x.OrderBy(y => y.CreatedTime),
            TicketAccountDefinitionPagedListOrderEnum.CreatedTimeDescending => x => x.OrderByDescending(y => y.CreatedTime),
            _ => null,
        };

        return PaginationRepository.GetPagedListAsync<TicketAccountDefinitionListItemDto>(request.Page, request.PageSize, filter, orderBy, cancellationToken);
    }

    public async ValueTask<bool> ToggleStatusAsync(TicketAccountDefinitionGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        var result = await SwitchRepository.ToggleStatusAsync(request.Id, cancellationToken);
        return result > 1;
    }
}