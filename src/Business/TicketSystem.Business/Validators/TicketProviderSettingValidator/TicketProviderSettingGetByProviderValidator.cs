using FluentValidation;
using TicketSystem.Dto.TicketProviderSetting;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators.TicketProviderSettingValidator;

internal sealed class TicketProviderSettingGetByProviderValidator : AbstractValidator<TicketProviderSettingGetByProviderRequestDto>
{
    public TicketProviderSettingGetByProviderValidator()
    {
        RuleFor(x => x.Provider).NotEqual(TicketSystemTypeEnum.None).NotNull();
    }
}