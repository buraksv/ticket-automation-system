using FluentValidation;
using TicketSystem.Dto.TicketProviderSetting;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators.TicketProviderSettingValidator;

internal sealed class TicketProviderSettingUpdateValidator : AbstractValidator<TicketProviderSettingUpdateRequestDto>
{
    public TicketProviderSettingUpdateValidator()
    {
        RuleFor(x => x.Key).MaximumLength(128).NotNull();
        RuleFor(x => x.Value).MaximumLength(2048).NotNull();
        RuleFor(x => x.Provider).NotEqual(TicketSystemTypeEnum.None).NotNull();
    }
}