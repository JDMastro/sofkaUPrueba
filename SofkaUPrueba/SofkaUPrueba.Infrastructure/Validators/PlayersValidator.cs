using FluentValidation;
using SofkaUPrueba.Core.DTOs;

namespace SofkaUPrueba.Infrastructure.Validators
{
    public class PlayersValidator : AbstractValidator<PlayersDto>
    {
        public PlayersValidator()
        {
            RuleFor(Player => Player.Username)
                .Length(3, 10);

            RuleFor(Player => Player.Password)
                .Length(6, 10)
                .NotNull();
        }
    }
}
