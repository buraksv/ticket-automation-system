using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketAccountDefinitions;

public sealed class TicketAccountDefinitionGetByIdRequestDto : IDto
{
    public int Id { get; set; }
}