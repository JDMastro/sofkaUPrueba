using FluentValidation;
using SofkaUPrueba.Core.DTOs;

namespace SofkaUPrueba.Infrastructure.Validators
{
    public class PlayersValidator : AbstractValidator<PlayersDto>
    {
        public PlayersValidator()
        {
            RuleFor(Player => Player.Username)
                .Length(1, 100);

            RuleFor(Player => Player.Password)
                .Length(1, 100)
                .NotNull();
        }
    }
}
