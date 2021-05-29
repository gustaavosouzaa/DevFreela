using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}
