using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.Admin;

public sealed class AdminLoginListItemDto : IDto
{
    public short? AdminId { get; set; }
    public string IpAddress { get; set; }
    public bool IsSuccess { get; set; }
    public string InputUsername { get; set; }
    public string InputPassword { get; set; }
    public DateTime CreatedTime { get; set; }

    public AdminDetailDto? Admin { get; set; }
}