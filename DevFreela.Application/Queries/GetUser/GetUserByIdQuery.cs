using DevFreela.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
