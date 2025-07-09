using Gronio.Utility.Common.Models.Exceptions;
using TicketSystem.Business.Contract.BusinessRules;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.Admin;

namespace TicketSystem.Business.BusinessRules;

internal sealed class AdminBusinessRules : IAdminBusinessRules
{
    private readonly IAdminRepository _adminRepository;

    public AdminBusinessRules(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task ControlMultipleControlFromCreate(AdminCreateRequestDto request)
    {
        var isExits = await _adminRepository.ControlAndGetMultipleRecordFromInsert(request);

        if (isExits)
        {
            throw new RecordAlreadyExistsException($"{request.Username} kullanıcı adi ile admin daha önceden eklenmiştir");
        }
    }

    public async Task ControlMultipleControlFromUpdate(AdminUpdateRequestDto request)
    {
        var isExits = await _adminRepository.ControlAndGetMultipleRecordFromUpdate(request);

        if (isExits)
        {
            throw new RecordAlreadyExistsException($"{request.Username} kullanıcı adi ile admin daha önceden eklenmiştir");
        }
    }
}