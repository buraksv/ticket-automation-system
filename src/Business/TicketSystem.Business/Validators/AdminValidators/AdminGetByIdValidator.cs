using FluentValidation;
using TicketSystem.Dto.Admin;

namespace TicketSystem.Business.Validators;

internal sealed class AdminGetByIdValidator : AbstractValidator<AdminGetByIdRequestDto>
{
    public AdminGetByIdValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan((short)0);
    }
}