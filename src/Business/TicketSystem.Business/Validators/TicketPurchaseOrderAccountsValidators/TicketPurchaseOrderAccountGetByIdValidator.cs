using FluentValidation;
using TicketSystem.Dto.TicketPurchaseOrderAccounts;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPurchaseOrderAccountGetByIdValidator : AbstractValidator<TicketPurchaseOrderAccountGetByIdRequestDto>
{
    public TicketPurchaseOrderAccountGetByIdValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}