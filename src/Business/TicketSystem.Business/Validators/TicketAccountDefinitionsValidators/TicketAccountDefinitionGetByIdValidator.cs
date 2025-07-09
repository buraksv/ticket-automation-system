using FluentValidation;
using TicketSystem.Dto.TicketAccountDefinitions;

namespace TicketSystem.Business.Validators;

internal sealed class TicketAccountDefinitionGetByIdValidator : AbstractValidator<TicketAccountDefinitionGetByIdRequestDto>
{
    public TicketAccountDefinitionGetByIdValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}