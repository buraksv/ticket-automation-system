using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.Admin;

public sealed class AdminChangePasswordRequestDto : IDto
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}