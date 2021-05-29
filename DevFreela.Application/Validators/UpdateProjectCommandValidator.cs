using DevFreela.Application.Commands.UpdateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    class UpdateUserValidationCommand : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateUserValidationCommand()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de descrição é de 255 caracteres.");

            RuleFor(p => p.Title)
               .MaximumLength(30)
               .WithMessage("Tamanho máximo de Título é de 30 caracteres");
        }
    }
}
