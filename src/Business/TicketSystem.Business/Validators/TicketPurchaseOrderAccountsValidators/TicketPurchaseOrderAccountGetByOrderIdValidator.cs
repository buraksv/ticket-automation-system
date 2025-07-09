using FluentValidation;
using TicketSystem.Dto.TicketPurchaseOrderAccounts;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPurchaseOrderAccountGetByOrderIdValidator : AbstractValidator<TicketPurchaseOrderAccountGetByOrderIdRequestDto>
{
    public TicketPurchaseOrderAccountGetByOrderIdValidator()
    {
        RuleFor(x => x.OrderId).NotNull().GreaterThan(0);
    }
}