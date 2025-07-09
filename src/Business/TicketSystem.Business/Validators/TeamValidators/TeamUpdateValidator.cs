using FluentValidation;
using TicketSystem.Dto.Teams;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators;

internal sealed class TeamUpdateValidator : AbstractValidator<TeamUpdateRequestDto>
{
    public TeamUpdateValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan((short)0);
        RuleFor(x => x.TeamName).NotEmpty().MaximumLength(128);
        RuleFor(x => x.TicketSystem).NotEqual(TicketSystemTypeEnum.None).IsInEnum(); 
    }
}