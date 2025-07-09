using FluentValidation;
using TicketSystem.Dto.EventLogs;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators.EventLogValidators;

internal sealed class EventLogAddValidator : AbstractValidator<EventLogCreateRequestDto>
{
    public EventLogAddValidator()
    {
        RuleFor(x => x.AdminId).GreaterThan((short)0).When(x => x.AdminId.HasValue);
        RuleFor(x => x.IpAddress).NotEmpty().When(x => x.AdminId.HasValue);
        RuleFor(x => x.Type).NotEqual(EventLogTypeEnum.None);
        RuleFor(x => x.Message).MaximumLength(1024);
    }
}