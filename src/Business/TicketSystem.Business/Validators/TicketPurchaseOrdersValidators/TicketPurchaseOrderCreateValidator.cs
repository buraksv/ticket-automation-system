using FluentValidation;
using TicketSystem.Dto.TicketPurchaseOrders;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPurchaseOrderCreateValidator : AbstractValidator<TicketPurchaseOrderCreateRequestDto>
{
    public TicketPurchaseOrderCreateValidator()
    {
        RuleFor(y => y.Name).MaximumLength(256);
        RuleFor(y => y.AdminId).GreaterThan((short)0);
        RuleFor(y => y.TeamId).GreaterThan((short)0);
        RuleFor(y => y.TicketSystemType).NotEqual(TicketSystemTypeEnum.None).IsInEnum();
        RuleFor(x => x.TicketPlaceId).GreaterThan((short)0);
        RuleFor(x => x.TicketEventId).NotEmpty().MaximumLength(128);
        RuleFor(x => x.EventDate).GreaterThan(DateTime.Now);
        RuleFor(x => x.AutomationRunTime).LessThan(y => y.EventDate);
    }
}