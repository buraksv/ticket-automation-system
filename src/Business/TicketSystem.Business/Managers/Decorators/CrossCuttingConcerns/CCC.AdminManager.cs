using Gronio.Database.Abstraction;
using Gronio.Utility.Extensions;
using Gronio.Utility.Helper.Core;
using Gronio.Utility.Helper.Validation;
using Microsoft.Extensions.Options;
using TicketSystem.Business.Contract.BusinessRules;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Managers.Main;
using TicketSystem.Business.Validators;
using TicketSystem.Common.Models.Configurations;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.Admin;
using TicketSystem.Dto.EventLogs;
using TicketSystem.Enums;

namespace TicketSystem.Business.Managers;

internal sealed class CccAdminManager : AdminManager
{
    private readonly IAdminBusinessRules _adminBusinessRules;
    private readonly IAdminLoginLogRepository _adminLoginLogRepository;
    private readonly IEventLogManager _eventLogManager;

    public CccAdminManager(IAdminRepository adminRepository, IAdminBusinessRules adminBusinessRules, IOptionsMonitor<AppSettingConfiguration> options, IEventLogManager eventLogManager, IAdminLoginLogRepository adminLoginLogRepository)
        : base(adminRepository, options)
    {
        _adminBusinessRules = adminBusinessRules;
        _eventLogManager = eventLogManager;
        _adminLoginLogRepository = adminLoginLogRepository;
    }

    public override async ValueTask<AdminDetailDto> CreateAsync(AdminCreateRequestDto request, CancellationToken cancellationToken = default)
    {
        ValidationHelper.Validate<AdminCreateValidator>(request);

        BusinessRuleRunner.Run(async () => await _adminBusinessRules.ControlMultipleControlFromCreate(request));

        var result = await base.CreateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Yeni Admin Eklendi => {request.Username}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override async ValueTask<AdminDetailDto> UpdateAsync(AdminUpdateRequestDto request, CancellationToken cancellationToken = default)
    {
        ValidationHelper.Validate<AdminUpdateValidator>(request);

        BusinessRuleRunner.Run(async () => await _adminBusinessRules.ControlMultipleControlFromUpdate(request));

        var result = await base.UpdateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Admin Güncellendi => {request.Username}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override ValueTask<AdminDetailDto> GetByIdAsync(AdminGetByIdRequestDto request, CancellationToken cancellationToken = default)
    {
        ValidationHelper.Validate<AdminGetByIdValidator>(request);

        return base.GetByIdAsync(request, cancellationToken);
    }

    public override ValueTask<PagedResult<AdminListItemDto>> PagedListAsync(AdminSearchRequestDto request, CancellationToken cancellationToken = default)
    {
        ValidationHelper.Validate<AdminPagedListValidator>(request);

        return base.PagedListAsync(request, cancellationToken);
    }

    public override async ValueTask<bool> ToggleStatusAsync(AdminGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = default)
    {
        ValidationHelper.Validate<AdminGetByIdValidator>(request);

        var result = await base.ToggleStatusAsync(request, adminId, ipAddress, cancellationToken);

        if (result)
        {
            var eventLogRequest = new EventLogCreateRequestDto
            {
                AdminId = adminId,
                IpAddress = ipAddress,
                Message = $"Admin Güncellendi => {request.Id}",
                Type = EventLogTypeEnum.Information,
            };

            await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);
        }

        return result;
    }

    public override async ValueTask<AdminLoginResponseDto> LoginAsync(AdminLoginRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<AdminLoginValidator>(request);

        var result = await base.LoginAsync(request, cancellationToken);

        if (result.Success)
        {
            var loginLog = new AdminLogin
            {
                AdminId = result.AdminId, 
                IsSuccess = true,
                IpAddress = request.IpAddress,
            };

            await _adminLoginLogRepository.AddAsync(loginLog, cancellationToken);
        }
        else
        {
            var loginLog = new AdminLogin
            {
                IsSuccess = false,
                IpAddress = request.IpAddress,
                InputUsername = request.Username,
                InputPassword = request.Password.MaskValueWithoutFirstAndLastLetter('*'),
            };

            await _adminLoginLogRepository.AddAsync(loginLog, cancellationToken);
        }

        return result;
    }
}