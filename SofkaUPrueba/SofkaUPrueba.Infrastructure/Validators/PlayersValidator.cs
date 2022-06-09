using FluentValidation;
using SofkaUPrueba.Core.DTOs;

namespace SofkaUPrueba.Infrastructure.Validators
{
    internal class PlayersValidator : AbstractValidator<PlayersDto>
    {
        public PlayersValidator()
        {
            RuleFor(Player => Player.Username)
                .NotEmpty()
                .NotNull();

            RuleFor(Player => Player.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
