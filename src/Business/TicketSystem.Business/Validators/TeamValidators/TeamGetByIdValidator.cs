using FluentValidation;
using TicketSystem.Dto.Teams;

namespace TicketSystem.Business.Validators;

internal sealed class TeamGetByIdValidator : AbstractValidator<TeamGetByIdRequestDto>
{
    public TeamGetByIdValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan((short)0);
    }
}