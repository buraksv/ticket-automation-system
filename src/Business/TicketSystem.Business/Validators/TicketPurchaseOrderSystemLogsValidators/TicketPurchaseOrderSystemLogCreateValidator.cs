using FluentValidation;
using TicketSystem.Dto.TicketPurchaseOrderSystemLogs;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPurchaseOrderSystemLogCreateValidator : AbstractValidator<TicketPurchaseOrderSystemLogCreateRequestDto>
{
    public TicketPurchaseOrderSystemLogCreateValidator()
    {
        RuleFor(x => x.LogType).NotEqual(SystemLogTypeEnum.None);
        RuleFor(x => x.LogMessage).NotEmpty().MaximumLength(2048);
    }
}