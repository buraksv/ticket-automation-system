using Gronio.Database.Abstraction;
using Gronio.Utility.Extensions;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.Admin;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Repository;

internal sealed class AdminRepository : RepositoryFactory<Admin, short>, IAdminRepository
{
    public AdminRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> AddAsync(Admin entity, CancellationToken cancellationToken = default)
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<bool> UpdateAsync(Admin entity, CancellationToken cancellationToken = default)
    {
        UpdateRepository.Update(entity);
        var result = await UpdateRepository.SaveAsync(cancellationToken);

        return result > 0;
    }

    public async ValueTask<AdminDetailDto> GetByIdAsync(AdminGetByIdRequestDto request, CancellationToken cancellationToken = default)
    {
        return await QueryRepository.GetByIdFirstOrDefaultAsync<AdminDetailDto>(request.Id, cancellationToken: cancellationToken);
    }

    public ValueTask<PagedResult<AdminListItemDto>> PagedListAsync(AdminSearchRequestDto request, CancellationToken cancellationToken = default)
    {
        var filter = PredicateBuilder.True<Admin>();
        if (request.SearchTerm.IsNotNullOrEmptyAndWhiteSpace())
        {
            filter = filter.And(x => x.Username.ToLower().Contains(request.SearchTerm.ToLower()) || x.Name.ToLower().Contains(request.SearchTerm.ToLower()) || x.Surname.ToLower().Contains(request.SearchTerm.ToLower()));
            filter = filter.Or(x => x.Id.ToString() == request.SearchTerm);
        }

        Func<IQueryable<Admin>, IOrderedQueryable<Admin>> orderBy = request.Order switch
        {
            AdminPagedListOrderEnum.UserNameAscending => x => x.OrderBy(y => y.Username),
            AdminPagedListOrderEnum.UserNameDescending => x => x.OrderByDescending(y => y.Username),
            AdminPagedListOrderEnum.CreatedTimeAscending => x => x.OrderBy(y => y.CreatedTime),
            AdminPagedListOrderEnum.CreatedTimeDescending => x => x.OrderByDescending(y => y.CreatedTime),
            _ => null,
        };

        return PaginationRepository.GetPagedListAsync<AdminListItemDto>(request.Page, request.PageSize, filter, orderBy, cancellationToken);
    }

    public async ValueTask<bool> ToggleStatusAsync(AdminGetByIdRequestDto request, CancellationToken cancellationToken = default)
    {
        var result = await SwitchRepository.ToggleStatusAsync(request.Id, cancellationToken);
        return result > 1;
    }

    public async ValueTask<AdminDetailDto> LoginAsync(string userName, string passwordHash, CancellationToken cancellationToken = default)
    {
        return await QueryRepository.GetFirstOrDefaultAsync<AdminDetailDto>(a => a.Username == userName && a.PasswordHash == passwordHash,
                cancellationToken: cancellationToken);
    }

    public async ValueTask<bool> ControlAndGetMultipleRecordFromInsert(AdminCreateRequestDto request)
    {
        return await QueryRepository.ExistsAsync(x => x.Username.ToLower() == request.Username.ToLower());
    }

    public async ValueTask<bool> ControlAndGetMultipleRecordFromUpdate(AdminUpdateRequestDto request)
    {
        return await QueryRepository.ExistsAsync(x => x.Username.ToLower() == request.Username.ToLower() && x.Id != request.Id);
    }
}