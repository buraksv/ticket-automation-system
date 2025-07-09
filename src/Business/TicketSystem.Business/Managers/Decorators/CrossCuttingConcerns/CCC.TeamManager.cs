using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Validation;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Managers.Main;
using TicketSystem.Business.Validators;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.EventLogs;
using TicketSystem.Dto.Teams;
using TicketSystem.Enums;

namespace TicketSystem.Business.Managers;

internal sealed class CccTeamManager : TeamManager
{
    private readonly IEventLogManager _eventLogManager;

    public CccTeamManager(ITeamRepository teamRepository, IEventLogManager eventLogManager)
        : base(teamRepository)
    {
        _eventLogManager = eventLogManager;
    }

    public override async ValueTask<TeamDetailDto> CreateAsync(TeamCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TeamCreateValidator>(request);

        var result = await base.CreateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Yeni Takım Eklendi => {request.TeamName}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override ValueTask<TeamDetailDto> GetByIdAsync(TeamGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TeamGetByIdValidator>(request);

        return base.GetByIdAsync(request, cancellationToken);
    }

    public override async ValueTask<TeamDetailDto> UpdateAsync(TeamUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TeamUpdateValidator>(request);

        var result = await base.UpdateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Takım Güncellendi => {request.TeamName}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override ValueTask<PagedResult<TeamListItemDto>> PagedListAsync(TeamSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TeamPagedListValidator>(request);

        return base.PagedListAsync(request, cancellationToken);
    }

    public override async ValueTask<bool> ToggleStatusAsync(TeamGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TeamGetByIdValidator>(request);

        var result = await base.ToggleStatusAsync(request, adminId, ipAddress, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = adminId,
            IpAddress = ipAddress,
            Message = $"Takım Aktif/Pasif durumu güncellendi => {request.Id}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }
}