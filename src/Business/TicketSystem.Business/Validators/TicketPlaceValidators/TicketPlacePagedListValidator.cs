using FluentValidation;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.TicketPlaces;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPlacePagedListValidator : AbstractValidator<TicketPlaceSearchRequestDto>
{
    public TicketPlacePagedListValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(ApplicationConstants.PagedListMaxPageSize);
    }
}