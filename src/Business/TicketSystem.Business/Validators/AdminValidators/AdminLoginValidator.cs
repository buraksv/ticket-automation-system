using FluentValidation;
using TicketSystem.Dto.Admin;

namespace TicketSystem.Business.Validators;

internal sealed class AdminLoginValidator : AbstractValidator<AdminLoginRequestDto>
{
    public AdminLoginValidator()
    {
        RuleFor(x => x.Username).NotEmpty().Length(3, 128);
        RuleFor(x => x.Password).NotEmpty().Length(6, 24);
    }
}