using FluentValidation;
using TicketSystem.Dto.TicketPurchaseOrderAccounts;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPurchaseOrderAccountCreateValidator : AbstractValidator<TicketPurchaseOrderAccountCreateRequestDto>
{
    public TicketPurchaseOrderAccountCreateValidator()
    {
        RuleFor(x => x.AdminId).GreaterThan((short)0);
        RuleFor(x => x.Count).GreaterThan((short)-1);
        RuleFor(x => x.OrderedCount).GreaterThan((short)-1);
        RuleFor(x => x.TicketPurchaseOrderId).GreaterThan(0);
        RuleFor(x => x.TicketAccountDefinitionId).GreaterThan(0);
        RuleFor(x => x.TicketEventOrderSelections).NotEmpty().Must(x => x.Count > 0);
    }
}