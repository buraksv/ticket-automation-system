using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.Teams;

public sealed class TeamGetByIdRequestDto : IDto
{
    public short Id { get; set; }
}