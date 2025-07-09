using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.Admin;

public sealed class AdminGetByIdRequestDto : IDto
{
    public short Id { get; set; }
}