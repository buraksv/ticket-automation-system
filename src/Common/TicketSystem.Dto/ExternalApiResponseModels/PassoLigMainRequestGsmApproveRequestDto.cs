using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.ExternalApiResponseModels;

public sealed class PassoLigMainRequestGsmApproveRequestDto : IDto
{
    public string OtpCode { get; set; }
}
