using FluentValidation;
using TicketSystem.Dto.Teams;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators;

internal sealed class TeamCreateValidator : AbstractValidator<TeamCreateRequestDto>
{
    public TeamCreateValidator()
    {
        RuleFor(x => x.TeamName).NotEmpty().MaximumLength(128);
        RuleFor(x => x.AdminId).GreaterThan((short)0);
        RuleFor(x => x.TicketSystem).NotEqual(TicketSystemTypeEnum.None).IsInEnum(); 
    }
}