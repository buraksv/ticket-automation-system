using FluentValidation;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.TicketPurchaseOrderSystemLogs;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPurchaseOrderSystemLogPagedListValidator : AbstractValidator<TicketPurchaseOrderSystemLogSearchRequestDto>
{
    public TicketPurchaseOrderSystemLogPagedListValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0).LessThanOrEqualTo(ApplicationConstants.PagedListMaxPageSize);
    }
}