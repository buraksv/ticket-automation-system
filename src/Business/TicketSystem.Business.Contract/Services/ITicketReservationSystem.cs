using Gronio.Utility.Helper.Core.BusinessEngine;

namespace TicketSystem.Business.Contract.Services;

public interface ITicketReservationSystem : IBusinessEngine
{
    ValueTask<object> LoginAsync(object request, CancellationToken cancellationToken = new());
    ValueTask<object> CheckAuthorizationAsync(object request, CancellationToken cancellationToken = new());
    ValueTask<object> GetCampaignListAsync(object request, CancellationToken cancellationToken = new());
    ValueTask<object> GetCategoriesAsync(object request, CancellationToken cancellationToken = new());
    ValueTask<object> GetVariantsAsync(object request, CancellationToken cancellationToken = new());
    ValueTask<object> GetAvailableListAsync(object request, CancellationToken cancellationToken = new());
    ValueTask<object> GetAllSeatsAsync(object request, CancellationToken cancellationToken = new());
    ValueTask<object> AddBasketAsync(object request, CancellationToken cancellationToken = new());
    ValueTask<object> SaveTicketAsync(object request, CancellationToken cancellationToken = new());
    ValueTask<object> RunTicketAddBasketActionsAsync(object request, CancellationToken cancellationToken = new());
}