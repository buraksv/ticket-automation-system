using FluentValidation;
using TicketSystem.Dto.TicketPurchaseCompletedOrders;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPurchaseCompletedOrderUpdateValidator : AbstractValidator<TicketPurchaseCompletedOrderUpdateRequestDto>
{
    public TicketPurchaseCompletedOrderUpdateValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
        RuleFor(x => x.TicketPrice).GreaterThan(0); 
    }
}