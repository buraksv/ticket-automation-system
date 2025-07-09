using FluentValidation;
using TicketSystem.Dto.SystemSettings;

namespace TicketSystem.Business.Validators;

internal sealed class SystemSettingsUpdateValidator : AbstractValidator<SystemSettingsUpdateRequestDto>
{
    public SystemSettingsUpdateValidator()
    {
        RuleFor(x => x.SystemName).NotEmpty().MaximumLength(64);
    }
}