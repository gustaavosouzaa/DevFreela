using DevFreela.Application.Commands.CreateProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo da descrição é de 255 caracteres.");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Tamanho máximo do título é de 30 caracteres.");

            RuleFor(p => p.IdClient)
               .NotEqual(0)
               .WithMessage("Código do cliente inválido.");

            RuleFor(p => p.IdFreelancer)
               .NotEqual(0)
               .WithMessage("Código do freelancer inválido.");
        }
    }
}
