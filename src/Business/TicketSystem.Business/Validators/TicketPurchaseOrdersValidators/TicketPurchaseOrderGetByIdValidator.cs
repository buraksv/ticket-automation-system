using FluentValidation;
using TicketSystem.Dto.TicketPurchaseOrders;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPurchaseOrderGetByIdValidator : AbstractValidator<TicketPurchaseOrderGetByIdRequestDto>
{
    public TicketPurchaseOrderGetByIdValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}