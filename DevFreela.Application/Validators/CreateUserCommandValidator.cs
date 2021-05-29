
using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido!");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("A senha deve conter no mínimo oito caracteres, pelo menos uma letra, um número e um caractere especial.");

            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome obrigatório!");

        }

        public bool ValidPassword(string password)
        {
            //Mínimo de oito caracteres, pelo menos uma letra, um número e um caractere especial
            var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");

            return regex.IsMatch(password);
        }
    }
}
