using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketPlaces;

public sealed class TicketPlaceGetByIdRequestDto : IDto
{
    public short Id { get; set; }
}