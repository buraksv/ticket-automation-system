using FluentValidation;
using TicketSystem.Dto.EventLogs;

namespace TicketSystem.Business.Validators.EventLogValidators;

internal sealed class EventLogGetValidator : AbstractValidator<EventLogListRequestDto>
{
    public EventLogGetValidator()
    {
        RuleFor(x => x.Limit).GreaterThanOrEqualTo(1);
        RuleFor(x => x.OffsetId).GreaterThanOrEqualTo(0);
    }
}