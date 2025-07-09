using FluentValidation;
using TicketSystem.Dto.TicketPlaces;
using TicketSystem.Enums;

namespace TicketSystem.Business.Validators;

internal sealed class TicketPlaceUpdateValidator : AbstractValidator<TicketPlaceUpdateRequestDto>
{
    public TicketPlaceUpdateValidator()
    {
        RuleFor(x => x.Id).GreaterThan((short)0);
        RuleFor(x => x.PlaceName).NotEmpty().MaximumLength(128);

        RuleFor(x => x.TicketPlaceConfigurations).NotNull();
        RuleFor(x => x.TicketPlaceConfigurations.Definitions).NotEmpty();
        RuleFor(x => x.TicketPlaceConfigurations.TicketSystem).NotEqual(TicketSystemTypeEnum.None);
        RuleFor(x => x.TicketPlaceConfigurations.TicketSystemId).NotEmpty().MaximumLength(128);
    }
}