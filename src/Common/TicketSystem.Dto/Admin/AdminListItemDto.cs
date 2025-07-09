using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.Admin;

public sealed class AdminListItemDto : IDto
{
    public short Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string MailAddress { get; set; }
    public string Username { get; set; }
    public DateTime CreatedTime { get; set; }
    public bool IsActive { get; set; }
}