using FluentValidation;
using TicketSystem.Dto.TicketPurchaseCompletedOrders;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPurchaseCompletedOrderGetByIdValidator : AbstractValidator<TicketPurchaseCompletedOrderGetByIdRequestDto>
{
    public TicketPurchaseCompletedOrderGetByIdValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}