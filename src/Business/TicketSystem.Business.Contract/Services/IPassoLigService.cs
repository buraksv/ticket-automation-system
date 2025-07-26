using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.ExternalApiResponseModels;

namespace TicketSystem.Business.Contract.Services;

public interface IPassoLigService : IBusinessEngine
{
    ValueTask<bool> GenerateMainTokenRequestAsync(CancellationToken cancellationToken = new());
    ValueTask<bool> GenerateMainRefreshTokenRequestAsync(CancellationToken cancellationToken = new());
    ValueTask<bool> ApproveMainTokenAsync(PassoLigMainRequestGsmApproveRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PassoLigLoginResponseModel> GetOrCreateCustomerPassoLigTokenDetailAsync(PassoLigLoginRequestModel request, CancellationToken cancellationToken = new());
}