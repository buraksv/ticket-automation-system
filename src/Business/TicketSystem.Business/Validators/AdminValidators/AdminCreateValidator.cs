using FluentValidation;
using TicketSystem.Dto.Admin;

namespace TicketSystem.Business.Validators;

internal sealed class AdminCreateValidator : AbstractValidator<AdminCreateRequestDto>
{
    public AdminCreateValidator()
    {
        RuleFor(x => x.Username).NotEmpty().Length(3, 128);
        RuleFor(x => x.Password).NotEmpty().Length(6, 24);
        RuleFor(x => x.Name).NotEmpty().Length(2, 64);
        RuleFor(x => x.Surname).NotEmpty().Length(2, 64);
        RuleFor(x => x.MailAddress)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(256);
    }
}