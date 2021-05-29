using DevFreela.Application.Commands.CreateComment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(p => p.Content)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de texto de comentário é de 255 caracteres.");
        }
    }
}
