using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.ExternalApiResponseModels;

public sealed class PassoLigLoginResponseModel : IDto
{
    public bool Success { get; set; }
    public Dictionary<string, string> LoginDetails { get; set; }
}
