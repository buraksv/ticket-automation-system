using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.Admin;

namespace TicketSystem.Business.Contract.BusinessRules;

public interface IAdminBusinessRules : IBusinessEngine
{
    Task ControlMultipleControlFromCreate(AdminCreateRequestDto request);
    Task ControlMultipleControlFromUpdate(AdminUpdateRequestDto request);
}