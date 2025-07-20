using FluentValidation;
using TicketSystem.Dto.TicketProviderSetting;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators.TicketProviderSettingValidator;

internal sealed class TicketProviderSettingGetDetailValidator : AbstractValidator<TicketProviderSettingGetByKeyRequestDto>
{
    public TicketProviderSettingGetDetailValidator()
    {
        RuleFor(x => x.Key).MaximumLength(128).NotNull();
        RuleFor(x => x.Provider).NotEqual(TicketSystemTypeEnum.None).NotNull();
    }
}