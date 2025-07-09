using FluentValidation;
using TicketSystem.Dto.TicketPurchaseCompletedOrders;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPurchaseCompletedOrderCreateValidator : AbstractValidator<TicketPurchaseCompletedOrderCreateRequestDto>
{
    public TicketPurchaseCompletedOrderCreateValidator()
    {
        RuleFor(x => x.TicketPrice).GreaterThan(0);
        RuleFor(x => x.TicketPurchaseOrderAccountId).GreaterThan(0);
        RuleFor(x => x.TicketPurchaseOrderId).GreaterThan(0);
        RuleFor(x => x.TicketOrderedInformations).NotEmpty().Must(x => x.Count > 0);
    }
}