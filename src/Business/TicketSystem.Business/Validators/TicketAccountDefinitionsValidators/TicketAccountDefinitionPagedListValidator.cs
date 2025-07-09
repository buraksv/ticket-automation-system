using FluentValidation;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.TicketAccountDefinitions;

namespace TicketSystem.Business.Validators;

internal sealed class TicketAccountDefinitionPagedListValidator : AbstractValidator<TicketAccountDefinitionSearchRequestDto>
{
    public TicketAccountDefinitionPagedListValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(ApplicationConstants.PagedListMaxPageSize);
    }
}