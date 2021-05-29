using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetUser
{
    class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var newUser = await _userRepository.GetByIdAsync(request.Id);

            if (newUser == null)
            {
                return null;
            }

            return new UserViewModel(newUser.FullName, newUser.Email);
        }
    }
}
