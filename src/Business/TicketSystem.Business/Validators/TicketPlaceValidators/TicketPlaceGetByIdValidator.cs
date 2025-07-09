using FluentValidation;
using TicketSystem.Dto.TicketPlaces;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPlaceGetByIdValidator : AbstractValidator<TicketPlaceGetByIdRequestDto>
{
    public TicketPlaceGetByIdValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan((short)0);
    }
}