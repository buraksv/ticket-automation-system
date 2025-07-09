using FluentValidation;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.Admin;

namespace TicketSystem.Business.Validators;

internal sealed class AdminPagedListValidator : AbstractValidator<AdminSearchRequestDto>
{
    public AdminPagedListValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(ApplicationConstants.PagedListMaxPageSize);
    }
}