using FluentValidation;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.Teams;

namespace TicketSystem.Business.Validators;

internal sealed class TeamPagedListValidator : AbstractValidator<TeamSearchRequestDto>
{
    public TeamPagedListValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(ApplicationConstants.PagedListMaxPageSize);
    }
}