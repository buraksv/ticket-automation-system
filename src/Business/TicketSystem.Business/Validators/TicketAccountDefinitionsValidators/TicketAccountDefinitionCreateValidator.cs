using FluentValidation;
using TicketSystem.Dto.TicketAccountDefinitions;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators;

internal sealed class TicketAccountDefinitionCreateValidator : AbstractValidator<TicketAccountDefinitionCreateRequestDto>
{
    public TicketAccountDefinitionCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(128);
        RuleFor(x => x.Surname).NotEmpty().MaximumLength(128);
        RuleFor(x => x.AccountType).NotEqual(TicketAccountTypeEnum.None).IsInEnum();
        RuleFor(x => x.AdminId).GreaterThan((short)0);
        RuleFor(x => x.TeamId).GreaterThan((short)0);
        RuleFor(x => x.TicketSystem).NotEqual(TicketSystemTypeEnum.None).IsInEnum();
        RuleFor(x => x.TicketSystemLoginInformation).NotEmpty().Must(x => x.Count > 0);
    }
}