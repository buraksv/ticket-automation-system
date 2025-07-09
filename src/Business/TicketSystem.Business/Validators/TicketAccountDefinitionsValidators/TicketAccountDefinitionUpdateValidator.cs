using FluentValidation;
using TicketSystem.Dto.TicketAccountDefinitions;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators;

internal sealed class TicketAccountDefinitionUpdateValidator : AbstractValidator<TicketAccountDefinitionUpdateRequestDto>
{
    public TicketAccountDefinitionUpdateValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(128);
        RuleFor(x => x.Surname).NotEmpty().MaximumLength(128);
        RuleFor(x => x.AccountType).NotEqual(TicketAccountTypeEnum.None).IsInEnum(); 
        RuleFor(x => x.TeamId).GreaterThan((short)0);
        RuleFor(x => x.TicketSystem).NotEqual(TicketSystemTypeEnum.None).IsInEnum();
        RuleFor(x => x.TicketSystemLoginInformation).NotEmpty().Must(x => x.Count > 0);
    }
}